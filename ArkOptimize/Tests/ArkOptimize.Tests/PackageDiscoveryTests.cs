using ArkOptimize.App;

namespace ArkOptimize.Tests;

public class PackageDiscoveryTests
{
    [Fact]
    public void DiscoverPackages_ReturnsManifestsFromModuleFolders()
    {
        var service = new OptimizationService();
        var rootPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "Modules");
        var packages = service.DiscoverPackages(rootPath);

        Assert.NotEmpty(packages);
        Assert.Contains(packages, p => p.Id == "ultimate-performance");
    }
}
