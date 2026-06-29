using Ark.Shared.Contracts;
using Ark.Shared.Licensing;
using Ark.Shared.Models;
using ArkOptimize.App;

var validator = new SafetyValidator();
var service = new OptimizationService();
var shell = new DashboardShell();
var licenseService = new LicenseService();
var snapshot = new HealthSnapshot(
    Environment.MachineName,
    Environment.OSVersion.VersionString,
    22.5,
    48.0,
    61.2,
    18.0,
    "Demo Mode");

var action = new OptimizationAction(
    "Gaming Profile",
    "Applies a safe performance profile for gaming sessions.",
    "Gaming",
    "Low",
    true,
    true,
    "Profiles\\Gaming\\restore.reg");

var tweaks = service.GetTweaksForProfile("gaming");
var restorePlan = service.BuildRestorePlan("gaming");
var license = licenseService.CreateDemoFallbackLicense("local@example.com");
var resolvedModulesRoot = Path.GetFullPath(service.ResolveModulesRoot());
var executionResults = service.ExecuteProfile("gaming", resolvedModulesRoot);

Console.WriteLine("Ark Optimize ready.");
Console.WriteLine($"License: {snapshot.LicenseStatus}");
Console.WriteLine($"Safety validation: {validator.Validate(action)}");
Console.WriteLine($"Loaded {tweaks.Count} tweak(s) for profile 'gaming'.");
Console.WriteLine($"Restore plan created: {restorePlan.Name}");
Console.WriteLine($"Dashboard shell: {shell.Title} - {shell.Subtitle}");
Console.WriteLine($"Activation state: {license.IsActive} ({license.Tier})");
Console.WriteLine("Demo mode enabled: tweaks can run without a paid license.");
Console.WriteLine("Executing available tweak scripts...");
foreach (var result in executionResults)
{
    Console.WriteLine(result);
}

public sealed class SafetyValidator : ISafetyValidator
{
    public bool Validate(OptimizationAction action) =>
        action.IsSafe && action.RequiresAdmin && !string.IsNullOrWhiteSpace(action.RestorePath);

    public Task<bool> ValidateAsync(OptimizationAction action, CancellationToken cancellationToken = default) =>
        Task.FromResult(Validate(action));
}
