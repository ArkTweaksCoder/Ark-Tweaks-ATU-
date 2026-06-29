namespace Ark.Shared.Models;

public sealed record OptimizationAction(
    string Name,
    string Description,
    string Category,
    string RiskLevel,
    bool RequiresAdmin,
    bool IsSafe,
    string RestorePath);
