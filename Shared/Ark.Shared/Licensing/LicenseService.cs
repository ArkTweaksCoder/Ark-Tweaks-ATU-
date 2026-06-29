namespace Ark.Shared.Licensing;

public sealed class LicenseService
{
    public bool IsFeatureUnlocked(LicenseModel? license, LicenseTier requiredTier)
    {
        if (license is null || !license.IsActive)
        {
            return requiredTier == LicenseTier.Free;
        }

        return (int)license.Tier >= (int)requiredTier;
    }

    public LicenseModel CreateDemoLicense(string email)
    {
        return new LicenseModel
        {
            UserEmail = email,
            LicenseKey = "ARK-DEMO-0001",
            Tier = LicenseTier.Standard,
            IsActive = true,
            ExpiresAt = DateTimeOffset.UtcNow.AddDays(14),
            MachineFingerprint = "demo-machine",
            ProductName = "Ark Optimize"
        };
    }

    public LicenseModel CreateDemoFallbackLicense(string email)
    {
        return new LicenseModel
        {
            UserEmail = email,
            LicenseKey = "ARK-DEMO-FALLBACK",
            Tier = LicenseTier.Free,
            IsActive = true,
            ExpiresAt = DateTimeOffset.UtcNow.AddDays(7),
            MachineFingerprint = "local-demo",
            ProductName = "Ark Optimize"
        };
    }
}
