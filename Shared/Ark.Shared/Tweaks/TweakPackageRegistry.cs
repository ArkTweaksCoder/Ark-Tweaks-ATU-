using System.Text.Json;

namespace Ark.Shared.Tweaks;

public static class TweakPackageRegistry
{
    public static IReadOnlyList<TweakPackageManifest> Discover(string rootPath)
    {
        if (!Directory.Exists(rootPath))
        {
            return Array.Empty<TweakPackageManifest>();
        }

        var manifests = new List<TweakPackageManifest>();
        foreach (var manifestPath in Directory.EnumerateFiles(rootPath, "Manifest.json", SearchOption.AllDirectories))
        {
            try
            {
                var json = File.ReadAllText(manifestPath);
                var manifest = JsonSerializer.Deserialize<TweakPackageManifest>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (manifest is not null)
                {
                    manifests.Add(manifest);
                }
            }
            catch
            {
                // Intentionally ignored for package discovery robustness.
            }
        }

        return manifests;
    }
}
