namespace Ark.Shared.Profiles;

public sealed record OptimizationProfile(
    string Id,
    string Name,
    string Description,
    string Category,
    string[] TweakIds,
    bool IsRecommended);
