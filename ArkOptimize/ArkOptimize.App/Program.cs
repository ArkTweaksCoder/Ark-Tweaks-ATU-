using Ark.Shared.Contracts;
using Ark.Shared.Licensing;
using Ark.Shared.Models;
using Ark.Shared.Tweaks;
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
    "Pro");

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
var license = licenseService.CreateDemoLicense("user@example.com");

Console.WriteLine($"Ark Optimize ready. License: {snapshot.LicenseStatus}");
Console.WriteLine($"Safety validation: {validator.Validate(action)}");
Console.WriteLine($"Loaded {tweaks.Count} tweak(s) for profile 'gaming'.");
Console.WriteLine($"Restore plan created: {restorePlan.Name}");
Console.WriteLine($"Dashboard shell: {shell.Title} - {shell.Subtitle}");
Console.WriteLine($"Activation state: {license.IsActive} ({license.Tier})");

public sealed class SafetyValidator : ISafetyValidator
{
    public bool Validate(OptimizationAction action) =>
        action.IsSafe && action.RequiresAdmin && !string.IsNullOrWhiteSpace(action.RestorePath);

    public Task<bool> ValidateAsync(OptimizationAction action, CancellationToken cancellationToken = default) =>
        Task.FromResult(Validate(action));
}
