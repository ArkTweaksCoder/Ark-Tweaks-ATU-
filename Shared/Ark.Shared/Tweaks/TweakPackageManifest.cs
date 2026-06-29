namespace Ark.Shared.Tweaks;

public sealed class TweakPackageManifest
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string WhyItHelps { get; set; } = string.Empty;
    public string[] SupportedWindows { get; set; } = ["10", "11"];
    public string RiskLevel { get; set; } = "Low";
    public bool RequiresAdmin { get; set; } = true;
    public bool IsSafe { get; set; } = true;
    public bool IsReversible { get; set; } = true;
    public string EnableScriptPath { get; set; } = string.Empty;
    public string DisableScriptPath { get; set; } = string.Empty;
    public string RestoreScriptPath { get; set; } = string.Empty;
    public string RegistryPath { get; set; } = string.Empty;
    public string ReadmePath { get; set; } = string.Empty;
    public string ModulePath { get; set; } = string.Empty;
}
