using System.Diagnostics;
using Ark.Shared.Profiles;
using Ark.Shared.Restore;
using Ark.Shared.Tweaks;

namespace ArkOptimize.App;

public sealed class OptimizationService
{
    public IReadOnlyList<TweakDefinition> GetTweaksForProfile(string profileId)
    {
        var profile = ProfileCatalog.All.FirstOrDefault(p => p.Id.Equals(profileId, StringComparison.OrdinalIgnoreCase));
        if (profile is null)
        {
            return Array.Empty<TweakDefinition>();
        }

        return TweakCatalog.All
            .Where(t => profile.TweakIds.Contains(t.Id))
            .ToList();
    }

    public RestorePlan BuildRestorePlan(string profileId)
    {
        var tweaks = GetTweaksForProfile(profileId);
        return RestorePlanner.CreatePlan(profileId, tweaks);
    }

    public IReadOnlyList<TweakPackageManifest> DiscoverPackages(string rootPath)
    {
        return TweakPackageRegistry.Discover(rootPath);
    }

    public string ResolveModulesRoot()
    {
        var current = new DirectoryInfo(AppContext.BaseDirectory);

        while (current is not null)
        {
            var directModules = Path.Combine(current.FullName, "Modules");
            if (Directory.Exists(directModules))
            {
                return directModules;
            }

            var arkOptimizeModules = Path.Combine(current.FullName, "ArkOptimize", "Modules");
            if (Directory.Exists(arkOptimizeModules))
            {
                return arkOptimizeModules;
            }

            current = current.Parent;
        }

        return Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Modules");
    }

    public IReadOnlyList<string> ExecuteProfile(string profileId, string modulesRoot)
    {
        var tweaks = GetTweaksForProfile(profileId);
        var results = new List<string>();

        foreach (var tweak in tweaks)
        {
            var modulePath = ResolveModulePath(modulesRoot, tweak);
            if (modulePath is null)
            {
                results.Add($"No module folder found for {tweak.Name}");
                continue;
            }

            var enableScript = Path.Combine(modulePath, "Enable.bat");
            var powershellScript = Path.Combine(modulePath, "Enable.ps1");

            if (File.Exists(enableScript))
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"{enableScript}\"",
                    WorkingDirectory = modulePath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                if (process is null)
                {
                    results.Add($"Failed to start {tweak.Name}");
                    continue;
                }

                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                results.Add($"{tweak.Name}: exit {process.ExitCode} {output.Trim()} {error.Trim()}".Trim());
                continue;
            }

            if (File.Exists(powershellScript))
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-ExecutionPolicy Bypass -File \"{powershellScript}\"",
                    WorkingDirectory = modulePath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                if (process is null)
                {
                    results.Add($"Failed to start {tweak.Name}");
                    continue;
                }

                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                results.Add($"{tweak.Name}: exit {process.ExitCode} {output.Trim()} {error.Trim()}".Trim());
                continue;
            }

            results.Add($"No executable script found for {tweak.Name}");
        }

        return results;
    }

    private static string? ResolveModulePath(string modulesRoot, TweakDefinition tweak)
    {
        if (string.IsNullOrWhiteSpace(modulesRoot) || !Directory.Exists(modulesRoot))
        {
            return null;
        }

        var normalizedTweakName = NormalizeToken(tweak.Name);
        var normalizedTweakId = NormalizeToken(tweak.Id);
        var normalizedCategory = NormalizeToken(tweak.Category);

        foreach (var directory in EnumerateModuleDirectories(modulesRoot))
        {
            var manifestPath = Path.Combine(directory, "Manifest.json");
            var hasScript = File.Exists(Path.Combine(directory, "Enable.bat")) || File.Exists(Path.Combine(directory, "Enable.ps1"));
            if (!hasScript && !File.Exists(manifestPath))
            {
                continue;
            }

            var directoryName = NormalizeToken(Path.GetFileName(directory));
            var manifestName = string.Empty;
            var manifestCategory = string.Empty;
            var manifestId = string.Empty;

            if (File.Exists(manifestPath))
            {
                var manifestText = File.ReadAllText(manifestPath);
                if (manifestText.Contains("\"name\"", StringComparison.OrdinalIgnoreCase))
                {
                    var matchName = System.Text.RegularExpressions.Regex.Match(manifestText, "\"name\"\\s*:\\s*\"([^\"]+)\"");
                    if (matchName.Success)
                    {
                        manifestName = NormalizeToken(matchName.Groups[1].Value);
                    }
                }

                if (manifestText.Contains("\"category\"", StringComparison.OrdinalIgnoreCase))
                {
                    var matchCategory = System.Text.RegularExpressions.Regex.Match(manifestText, "\"category\"\\s*:\\s*\"([^\"]+)\"");
                    if (matchCategory.Success)
                    {
                        manifestCategory = NormalizeToken(matchCategory.Groups[1].Value);
                    }
                }

                if (manifestText.Contains("\"id\"", StringComparison.OrdinalIgnoreCase))
                {
                    var matchId = System.Text.RegularExpressions.Regex.Match(manifestText, "\"id\"\\s*:\\s*\"([^\"]+)\"");
                    if (matchId.Success)
                    {
                        manifestId = NormalizeToken(matchId.Groups[1].Value);
                    }
                }
            }

            var matchesName = directoryName == normalizedTweakName || manifestName == normalizedTweakName || directoryName.Contains(normalizedTweakName) || normalizedTweakName.Contains(directoryName);
            var matchesId = manifestId == normalizedTweakId || directoryName.Contains(normalizedTweakId) || normalizedTweakId.Contains(directoryName);
            var matchesCategory = string.IsNullOrEmpty(normalizedCategory) || manifestCategory == normalizedCategory || directoryName.Contains(normalizedCategory) || normalizedCategory.Contains(directoryName);

            if (matchesName || matchesId || (matchesCategory && (matchesName || matchesId || string.IsNullOrEmpty(manifestName) && string.IsNullOrEmpty(manifestId))))
            {
                return directory;
            }
        }

        return null;
    }

    private static IEnumerable<string> EnumerateModuleDirectories(string root)
    {
        foreach (var categoryDirectory in Directory.GetDirectories(root))
        {
            foreach (var moduleDirectory in Directory.GetDirectories(categoryDirectory))
            {
                yield return moduleDirectory;
            }
        }
    }

    private static string NormalizeToken(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        return new string(value.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();
    }
}
