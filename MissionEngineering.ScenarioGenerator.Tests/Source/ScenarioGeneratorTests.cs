using MissionEngineering.Core.Source;
using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator.Tests;

[TestClass]
public sealed class ScenarioGeneratorTests
{
    [TestMethod]
    public void Run_WithValidData_ExpectSuccess()
    {
        // Arrange:
        var scenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();

        var scenarioGenerator = ScenarioBuilder.CreateScenarioGenerator();

        scenarioGenerator.ScenarioSettings = scenarioSettings;

        var expectedListLength = 901;
        
        // Act:
        scenarioGenerator.Run();

        var fp2 = scenarioGenerator.Scenario.FlightpathList[1];

        // Assert:
        Assert.AreEqual(expectedListLength, fp2.FlightpathDataList.Count);
    }
}