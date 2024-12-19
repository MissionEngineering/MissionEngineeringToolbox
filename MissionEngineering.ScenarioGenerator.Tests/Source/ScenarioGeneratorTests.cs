using MissionEngineering.Core;

namespace MissionEngineering.ScenarioGenerator.Tests;

[TestClass]
public sealed class ScenarioGeneratorTests
{
    [TestMethod]
    public void Run_WithValidData_ExpectSuccess()
    {
        // Arrange:
        MockUtilities.SetMock(false);

        var scenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();

        var scenarioGenerator = ScenarioBuilder.CreateScenarioGenerator();

        scenarioGenerator.ScenarioSettings = scenarioSettings;

        var expectedListLength = 1901;

        // Act:
        scenarioGenerator.Run();

        var fp2 = scenarioGenerator.Scenario.FlightpathList[1];

        // Assert:
        Assert.AreEqual(expectedListLength, fp2.FlightpathStateDataList.Count);
    }
}