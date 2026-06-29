using Ark.Shared.Models;

var snapshot = new HealthSnapshot(
    Environment.MachineName,
    Environment.OSVersion.VersionString,
    18.0,
    42.0,
    58.0,
    14.0,
    "Standard");

Console.WriteLine($"Ark Ping ready. Network profile: {snapshot.LicenseStatus}");
