using System.Collections.ObjectModel;

namespace Ark.Shared.Tweaks;

public static class TweakCatalog
{
    public static IReadOnlyList<TweakDefinition> All => new ReadOnlyCollection<TweakDefinition>(new List<TweakDefinition>
    {
        new(
            "gaming-ultimate-performance",
            "Ultimate Performance",
            "Gaming",
            "Applies a safe gaming-oriented performance profile without disabling critical services.",
            "HKCU\\Software\\ArkSuite\\Tweaks\\Gaming",
            "Low",
            true,
            true,
            "restore/gaming-ultimate-performance.reg",
            new[] { "gaming", "performance", "safe" }),
        new(
            "network-dns-cloudflare",
            "Cloudflare DNS",
            "Network",
            "Switches to a reputable public DNS provider for lower latency and safer browsing.",
            "HKCU\\Software\\ArkSuite\\Tweaks\\Network",
            "Low",
            true,
            true,
            "restore/network-dns-cloudflare.reg",
            new[] { "network", "dns", "safe" }),
        new(
            "windows-animations-off",
            "Reduce Animations",
            "Windows",
            "Disables non-essential window animations while keeping core UI functionality intact.",
            "HKCU\\Software\\ArkSuite\\Tweaks\\Windows",
            "Low",
            true,
            true,
            "restore/windows-animations-off.reg",
            new[] { "windows", "ui", "safe" }),
        new(
            "cleanup-temp-files",
            "Clean Temporary Files",
            "Cleanup",
            "Removes temporary files that are safe to delete without affecting personal data.",
            "HKCU\\Software\\ArkSuite\\Tweaks\\Cleanup",
            "Medium",
            true,
            true,
            "restore/cleanup-temp-files.reg",
            new[] { "cleanup", "storage", "safe" })
    });
}
