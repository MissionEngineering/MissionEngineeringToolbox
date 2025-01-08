using BenchmarkDotNet.Attributes;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

public class SimulationBenchmarks
{
    public int NumberOfRuns { get; set; }

    public SimulationSettings SimulationSettings { get; set; }

    public ScenarioSettings ScenarioSettings { get; set; }

    public List<FlightpathDemand> FlightpathDemands { get; set; }

    public ISimulationHarness SimulationHarness { get; set; }

    [Benchmark]
    public void RunSingle()
    {
        NumberOfRuns = 1;

        Run();
    }

    [Benchmark]
    public void RunMultiple()
    {
        NumberOfRuns = 10;

        Run();
    }

    private void Run()
    {
        GenerateSimulationSettings();
        GenerateScenarioSettings();
        GenerateFlightpathDemands();

        SimulationHarness = SimulationBuilder.CreateSimulationHarness();

        SimulationHarness.SimulationSettings = SimulationSettings;
        SimulationHarness.ScenarioSettings = ScenarioSettings;
        SimulationHarness.FlightpathDemandList.FlightpathDemands = FlightpathDemands;
        SimulationHarness.SimulationHarnessSettings.NumberOfRuns = NumberOfRuns;

        SimulationHarness.Run();
    }

    private void GenerateSimulationSettings()
    {
        if (NumberOfRuns == 1)
        {
            SimulationSettings = SimulationSettingsFactory.SimulationSettings_Test_1_Single();
        }
        else
        {
            SimulationSettings = SimulationSettingsFactory.SimulationSettings_Test_1_Multiple();
        }
    }

    private void GenerateScenarioSettings()
    {
        ScenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();
    }

    private void GenerateFlightpathDemands()
    {
        FlightpathDemands = FlightpathDemandFactory.FlightpathDemands_Test_1();
    }
}