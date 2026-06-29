namespace Ark.Shared.Tweaks;

public sealed record TweakDefinition(
    string Id,
    string Name,
    string Category,
    string Description,
    string RegistryLocation,
    string RiskLevel,
    bool RequiresAdmin,
    bool IsSafe,
    string RestoreFile,
    string[] Tags);
