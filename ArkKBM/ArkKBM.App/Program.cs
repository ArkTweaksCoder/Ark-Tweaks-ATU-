using Ark.Shared.Models;

var snapshot = new HealthSnapshot(
    Environment.MachineName,
    Environment.OSVersion.VersionString,
    19.0,
    36.0,
    55.0,
    9.0,
    "Ultimate");

Console.WriteLine($"Ark Mouse & Keyboard ready. License: {snapshot.LicenseStatus}");
