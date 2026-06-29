namespace Ark.Shared.Diagnostics;

public sealed record SystemDiagnostics(
    string Summary,
    string[] Findings,
    string[] Recommendations);

public static class DiagnosticsCatalog
{
    public static SystemDiagnostics CreateDefault() => new(
        "System diagnostics ready",
        new[] { "Safe profile catalog loaded", "Restore planning available", "Basic telemetry hooks prepared" },
        new[] { "Run a full health scan", "Review restore plans before applying tweaks", "Enable logging for all operations" });
}
