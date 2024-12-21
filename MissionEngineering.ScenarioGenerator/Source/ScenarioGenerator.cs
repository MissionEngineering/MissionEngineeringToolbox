using MissionEngineering.Core;
using MissionEngineering.DataRecorder;
using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public class ScenarioGenerator : IScenarioGenerator
{
    public ScenarioSettings ScenarioSettings { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public IScenario Scenario { get; set; }

    public IDataRecorder DataRecorder { get; set; }

    public ScenarioGenerator(IScenario scenario, ILLAOrigin llaOrigin, ISimulationClock simulationClock, IDataRecorder dataRecorder)
    {
        Scenario = scenario;
        LLAOrigin = llaOrigin;
        SimulationClock = simulationClock;
        DataRecorder = dataRecorder;
    }

    public void Run()
    {
        LogUtilities.LogInformation("Starting Simulation...");
        LogUtilities.LogInformation("");

        var clockSettings = ScenarioSettings.SimulationClockSettings;

        var time = clockSettings.TimeStart;

        Initialise(time);

        while (time <= clockSettings.TimeEnd)
        {
            Update(time);

            time += clockSettings.TimeStep;
        }

        Finalise(time);

        LogUtilities.LogInformation("");
        LogUtilities.LogInformation("Simulation Finished.");
        LogUtilities.LogInformation("");

        LogUtilities.CloseLog();
        CreateZipFile();
    }

    public void Initialise(double time)
    {
        LogUtilities.LogInformation("Initialise...");
        LogUtilities.LogInformation("");

        LLAOrigin.PositionLLA = ScenarioSettings.LLAOrigin;

        SimulationClock.DateTimeOrigin.DateTime = ScenarioSettings.SimulationClockSettings.DateTimeOrigin;

        Scenario.ScenarioSettings = ScenarioSettings;

        DataRecorder.SimulationData.ScenarioSettings = ScenarioSettings;

        Scenario.Initialise(time);

        DataRecorder.Initialise(time);

        var simulationSettingsString = DataRecorder.SimulationData.SimulationSettings.ConvertToJsonString();
        var scenarioSettingsString = DataRecorder.SimulationData.ScenarioSettings.ConvertToJsonString();

        LogUtilities.LogInformation($"Simulation Settings {Environment.NewLine} {simulationSettingsString}");
        LogUtilities.LogInformation($"Scenario Settings {Environment.NewLine} {scenarioSettingsString}");
    }

    public void Update(double time)
    {
        Scenario.Update(time);
    }

    public void Finalise(double time)
    {
        LogUtilities.LogInformation("Finalise...");
        LogUtilities.LogInformation("");

        Scenario.Finalise(time);

        var flightpathDataAll = GenerateFlightpathDataAll();

        DataRecorder.SimulationData.FlightpathStateDataAll = flightpathDataAll;

        DataRecorder.Finalise(time);
    }

    public List<FlightpathStateData> GenerateFlightpathDataAll()
    {
        var flightpathDataAll = Scenario.FlightpathList.SelectMany(x => x.FlightpathStateDataList).ToList();

        return flightpathDataAll;
    }

    public void CreateZipFile()
    {
        if (!DataRecorder.SimulationData.SimulationSettings.IsWriteData)
        {
            return;
        }

        var zipFileName = $"{DataRecorder.SimulationData.SimulationSettings.SimulationName}.zip";

        var zipFileNameFull = DataRecorder.SimulationData.SimulationSettings.GetFileNameFull(zipFileName);

        var isCloseLog = true;

        ZipUtilities.ZipDirectory(DataRecorder.SimulationData.SimulationSettings.OutputFolder, zipFileNameFull, isCloseLog);
    }
}