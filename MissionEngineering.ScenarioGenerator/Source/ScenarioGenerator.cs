using MissionEngineering.DataRecorder;
using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.SimdisLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public class ScenarioGenerator : IScenarioGenerator
{
    public ScenarioSettings ScenarioSettings { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public IScenario Scenario { get; set; }

    public IDataRecorder DataRecorder { get; set; }

    public ISimdisExporter SimdisExporter { get; set; }

    public ScenarioGenerator(IScenario scenario, ILLAOrigin llaOrigin, ISimulationClock simulationClock, IDataRecorder dataRecorder, ISimdisExporter simdisExporter)
    {
        Scenario = scenario;
        LLAOrigin = llaOrigin;
        SimulationClock = simulationClock;
        DataRecorder = dataRecorder;
        SimdisExporter = simdisExporter;
    }

    public void Run()
    {
        var clockSettings = ScenarioSettings.SimulationClockSettings;

        var time = clockSettings.TimeStart;

        Initialise(time);

        while (time <= clockSettings.TimeEnd)
        {
            Update(time);

            time += clockSettings.TimeStep;
        }

        Finalise(time);
    }

    public void Initialise(double time)
    {
        LLAOrigin.PositionLLA = ScenarioSettings.LLAOrigin;

        SimulationClock.DateTimeOrigin.DateTime = ScenarioSettings.SimulationClockSettings.DateTimeOrigin;

        Scenario.ScenarioSettings = ScenarioSettings;

        DataRecorder.SimulationData.ScenarioSettings = ScenarioSettings;

        Scenario.Initialise(time);

        DataRecorder.Initialise(time);
    }

    public void Update(double time)
    {
        Scenario.Update(time);
    }

    public void Finalise(double time)
    {
        Scenario.Finalise(time);

        var flightpathDataAll = GenerateFlightpathDataAll();

        DataRecorder.SimulationData.FlightpathStateDataAll = flightpathDataAll;

        DataRecorder.Finalise(time);

        SimdisExporter.GenerateSimdisData();
        SimdisExporter.WriteSimdisData();
    }

    public List<FlightpathStateData> GenerateFlightpathDataAll()
    {
        var flightpathDataAll = Scenario.FlightpathList.SelectMany(x => x.FlightpathStateDataList).ToList();

        return flightpathDataAll;
    }
}