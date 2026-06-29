namespace ArkOptimize.App;

public sealed class DashboardShell
{
    public string Title => "Ark Optimize";
    public string Subtitle => "Premium Windows optimization platform";

    public IReadOnlyList<DashboardSection> Sections { get; } =
    [
        new("Performance", "Tune CPU, memory, and GPU behavior with one-click profiles."),
        new("Gaming", "Optimize latency, input responsiveness, and shader cache behavior."),
        new("Diagnostics", "Review system health and rollback history before applying changes."),
        new("License", "Manage activation state, tier access, and subscription plans.")
    ];

    public string[] NavigationItems => [
        "Dashboard",
        "Optimize",
        "Gaming",
        "CPU",
        "GPU",
        "Memory",
        "Network",
        "Windows",
        "Cleanup",
        "Profiles",
        "Diagnostics",
        "License"
    ];
}

public sealed record DashboardSection(string Title, string Description);
