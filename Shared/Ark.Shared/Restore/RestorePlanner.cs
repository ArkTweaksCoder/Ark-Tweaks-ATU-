using Ark.Shared.Tweaks;

namespace Ark.Shared.Restore;

public static class RestorePlanner
{
    public static RestorePlan CreatePlan(string profileName, IEnumerable<TweakDefinition> tweaks)
    {
        var selected = tweaks.ToList();
        return new RestorePlan(
            $"restore-{profileName}",
            $"Restore plan for {profileName}",
            selected.Select(t => t.RestoreFile).ToArray(),
            selected.Select(t => t.Id).ToArray(),
            "Rollback is generated from safe restore files and can be reviewed before execution.");
    }

    public static IEnumerable<TweakDefinition> GetTweaksForProfile(string profileId)
    {
        return TweakCatalog.All.Where(t => profileId.Contains("gaming") && t.Category == "Gaming" ||
                                          profileId.Contains("streaming") && t.Category == "Network" ||
                                          profileId.Contains("balanced") && t.Category == "Windows");
    }
}
