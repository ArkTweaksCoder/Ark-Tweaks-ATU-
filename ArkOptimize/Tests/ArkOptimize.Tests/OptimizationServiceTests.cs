using ArkOptimize.App;

namespace ArkOptimize.Tests;

public class OptimizationServiceTests
{
    [Fact]
    public void GetTweaksForProfile_ReturnsConfiguredTweaks()
    {
        var service = new OptimizationService();

        var tweaks = service.GetTweaksForProfile("gaming");

        Assert.NotEmpty(tweaks);
        Assert.Contains(tweaks, t => t.Id == "gaming-ultimate-performance");
    }

    [Fact]
    public void BuildRestorePlan_ProducesExpectedPlan()
    {
        var service = new OptimizationService();

        var plan = service.BuildRestorePlan("gaming");

        Assert.Equal("restore-gaming", plan.Id);
        Assert.Contains(plan.TweakIds, id => id == "gaming-ultimate-performance");
    }
}
