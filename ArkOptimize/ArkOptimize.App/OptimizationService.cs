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
}
