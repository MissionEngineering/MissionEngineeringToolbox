using BenchmarkDotNet.Attributes;
using Microsoft.VSDiagnostics;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

[DotNetObjectAllocDiagnoser]
[DotNetObjectAllocJobConfiguration]
[CPUUsageDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 1, iterationCount: 1)]
public class SimulationBenchmarks
{
    public int NumberOfRuns { get; set; }

    public bool IsWriteData { get; set; }

    public SimulationSettings SimulationSettings { get; set; }

    public ScenarioSettings ScenarioSettings { get; set; }

    public List<FlightpathDemand> FlightpathDemands { get; set; }

    public ISimulationHarness SimulationHarness { get; set; }

    [Benchmark]
    public void RunSingleNoWriteData()
    {
        NumberOfRuns = 1;

        IsWriteData = false;

        Run();
    }

    //[Benchmark]
    //public void RunSingleWriteData()
    //{
    //    NumberOfRuns = 1;

    //    IsWriteData = true;

    //    Run();
    //}

    //[Benchmark]
    //public void RunMultiple()
    //{
    //    NumberOfRuns = 10;

    //    IsWriteData = true;

    //    Run();
    //}

    private void Run()
    {
        GenerateSimulationSettings();
        GenerateScenarioSettings();
        GenerateFlightpathDemands();

        SimulationSettings.IsWriteData = IsWriteData;
        SimulationSettings.IsCreateZipFile = IsWriteData;

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