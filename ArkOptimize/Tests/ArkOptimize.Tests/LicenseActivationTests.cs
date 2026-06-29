using Ark.Shared.Licensing;

namespace ArkOptimize.Tests;

public class LicenseActivationTests
{
    [Fact]
    public void Activate_ReturnsSuccessfulResultForValidInput()
    {
        var service = new LicenseActivationService();

        var result = service.Activate("ARK-TEST-001", "user@example.com", "machine-001");

        Assert.True(result.Success);
        Assert.NotNull(result.License);
        Assert.Equal("ARK-TEST-001", result.License!.LicenseKey);
    }
}
