namespace Ark.Shared.Models;

public sealed record HealthSnapshot(
    string SystemName,
    string WindowsVersion,
    double CpuUsagePercent,
    double MemoryUsagePercent,
    double DiskUsagePercent,
    double NetworkLatencyMs,
    string LicenseStatus);
