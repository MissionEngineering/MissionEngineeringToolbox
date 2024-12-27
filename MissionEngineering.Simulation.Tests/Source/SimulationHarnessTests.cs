namespace MissionEngineering.Simulation.Tests;

[TestClass]
public sealed class SimulationHarnessTests
{
    [TestMethod]
    public void Run_WithValidData_ExpectSuccess()
    {
        // Arrange:
        var simulationSettings = SimulationSettingsFactory.SimulationSettings_Test_1_Single();
        var scenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();
        var flightpathDemands = FlightpathDemandFactory.FlightpathDemands_Test_1();

        var simulationHarness = SimulationBuilder.CreateSimulationHarness();

        simulationHarness.SimulationHarnessSettings.NumberOfRuns = 1;

        simulationHarness.SimulationSettings = simulationSettings;
        simulationHarness.ScenarioSettings = scenarioSettings;
        simulationHarness.FlightpathDemandList.FlightpathDemands = flightpathDemands;

        var expectedListLength = 1901;

        // Act:
        simulationHarness.Run();

        var fp2 = simulationHarness.Simulation.Scenario.FlightpathList[1];

        // Assert:
        Assert.AreEqual(expectedListLength, fp2.FlightpathStateDataList.Count);
    }
}