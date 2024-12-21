using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation.Tests;

[TestClass]
public sealed class SimulationTests
{
    [TestMethod]
    public void Run_WithValidData_ExpectSuccess()
    {
        // Arrange:
        var simulationSettings = SimulationSettingsFactory.SimulationSettings_Test_1_Single();
        var scenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();
        var flightpathDemands = FlightpathDemandFactory.FlightpathDemands_Test_1();

        var simulation = SimulationBuilder.CreateSimulation();

        simulation.SimulationSettings = simulationSettings;
        simulation.ScenarioSettings = scenarioSettings;
        simulation.FlightpathDemandList.FlightpathDemands = flightpathDemands;
        simulation.Scenario.FlightpathDemandList.FlightpathDemands = flightpathDemands;
        simulation.DataRecorder.SimulationData.SimulationSettings = simulationSettings;

        var expectedListLength = 1901;

        // Act:
        simulation.Run();

        var fp2 = simulation.Scenario.FlightpathList[1];

        // Assert:
        Assert.AreEqual(expectedListLength, fp2.FlightpathStateDataList.Count);
    }
}