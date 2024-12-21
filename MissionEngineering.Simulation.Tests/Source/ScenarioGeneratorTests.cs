using MissionEngineering.Simulation;

namespace MissionEngineering.ScenarioGenerator.Tests;

[TestClass]
public sealed class ScenarioGeneratorTests
{
    [TestMethod]
    public void Run_WithValidData_ExpectSuccess()
    {
        // Arrange:
        var simulationSettings = SimulationSettingsFactory.SimulationSettings_Test_1();
        var scenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();

        var simulation = SimulationBuilder.CreateSimulation();

        simulation.SimulationSettings = simulationSettings;
        simulation.ScenarioSettings = scenarioSettings;

        simulation.DataRecorder.SimulationData.SimulationSettings.IsWriteData = false;

        var expectedListLength = 1901;

        // Act:
        simulation.Run();

        var fp2 = simulation.Scenario.FlightpathList[1];

        // Assert:
        Assert.AreEqual(expectedListLength, fp2.FlightpathStateDataList.Count);
    }
}