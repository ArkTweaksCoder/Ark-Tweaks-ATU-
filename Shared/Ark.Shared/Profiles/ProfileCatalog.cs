namespace Ark.Shared.Profiles;

public static class ProfileCatalog
{
    public static IReadOnlyList<OptimizationProfile> All => new List<OptimizationProfile>
    {
        new(
            "gaming",
            "Gaming",
            "Balanced profile for gaming sessions with safe performance-oriented tweaks.",
            "Gaming",
            new[] { "gaming-ultimate-performance", "windows-animations-off" },
            true),
        new(
            "streaming",
            "Streaming",
            "Optimizes for streaming workloads while keeping system stability intact.",
            "Productivity",
            new[] { "network-dns-cloudflare", "cleanup-temp-files" },
            false),
        new(
            "balanced",
            "Balanced",
            "A conservative profile for day-to-day use.",
            "General",
            new[] { "windows-animations-off" },
            true)
    };
}
