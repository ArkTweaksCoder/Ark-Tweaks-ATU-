using ArkOptimize.App;

namespace ArkOptimize.Tests;

public class DashboardShellTests
{
    [Fact]
    public void DashboardShell_ExposesPremiumSections()
    {
        var shell = new DashboardShell();

        Assert.NotEmpty(shell.Sections);
        Assert.Contains(shell.Sections, section => section.Title == "Performance");
        Assert.Contains("License", shell.NavigationItems);
    }
}
