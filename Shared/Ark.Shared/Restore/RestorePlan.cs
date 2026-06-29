namespace Ark.Shared.Restore;

public sealed record RestorePlan(
    string Id,
    string Name,
    string[] BackupFiles,
    string[] TweakIds,
    string Notes);
