using Ark.Shared.Licensing;

namespace ArkOptimize.Tests;

public class LicenseServiceTests
{
    [Fact]
    public void CreateDemoLicense_CreatesActiveLicense()
    {
        var service = new LicenseService();

        var license = service.CreateDemoLicense("demo@example.com");

        Assert.True(license.IsActive);
        Assert.Equal(LicenseTier.Standard, license.Tier);
    }

    [Fact]
    public void IsFeatureUnlocked_RespectsTierRequirements()
    {
        var service = new LicenseService();
        var license = new LicenseModel
        {
            IsActive = true,
            Tier = LicenseTier.Pro
        };

        Assert.True(service.IsFeatureUnlocked(license, LicenseTier.Standard));
        Assert.False(service.IsFeatureUnlocked(license, LicenseTier.Ultimate));
    }
}
