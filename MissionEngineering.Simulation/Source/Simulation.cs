using MissionEngineering.Core;
using MissionEngineering.DataRecorder;
using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

public class Simulation : ISimulation
{
    public SimulationSettings SimulationSettings { get; set; }

    public ScenarioSettings ScenarioSettings { get; set; }

    public IFlightpathDemandList FlightpathDemandList { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public IScenario Scenario { get; set; }

    public IDataRecorder DataRecorder { get; set; }

    private double nextDisplayTime;

    private int displayCount;

    public Simulation(SimulationSettings simulationSettings, ScenarioSettings scenarioSettings, IScenario scenario, ILLAOrigin llaOrigin, ISimulationClock simulationClock, IDataRecorder dataRecorder, IFlightpathDemandList flightpathDemandList)
    {
        SimulationSettings = simulationSettings;
        ScenarioSettings = scenarioSettings;
        Scenario = scenario;
        LLAOrigin = llaOrigin;
        SimulationClock = simulationClock;
        DataRecorder = dataRecorder;
        FlightpathDemandList = flightpathDemandList;
    }

    public void Run()
    {
        LogUtilities.LogInformation("");
        LogUtilities.LogInformation($"Run Number {SimulationSettings.RunNumber} Started...");
        LogUtilities.LogInformation("");

        var clockSettings = ScenarioSettings.SimulationClockSettings;

        var time = clockSettings.TimeStart;

        Initialise(time);

        LogUtilities.LogInformation("Run Started...");
        LogUtilities.LogInformation("");

        while (time <= clockSettings.TimeEnd)
        {
            ShowProgress(time);

            Update(time);

            time += clockSettings.TimeStep;
        }

        LogUtilities.LogInformation("");
        LogUtilities.LogInformation("Run Finished.");
        LogUtilities.LogInformation("");

        Finalise(time);

        LogUtilities.LogInformation($"Run Number {SimulationSettings.RunNumber} Finished.");
        LogUtilities.LogInformation("");

        CreateZipFile();
    }

    public void Initialise(double time)
    {
        LogUtilities.LogInformation("Initialise Started...");
        LogUtilities.LogInformation("");

        LLAOrigin.PositionLLA = ScenarioSettings.LLAOrigin;

        SimulationClock.DateTimeOrigin.DateTime = ScenarioSettings.SimulationClockSettings.DateTimeOrigin;

        Scenario.ScenarioSettings = ScenarioSettings;

        DataRecorder.SimulationData.ScenarioSettings = ScenarioSettings;

        Scenario.Initialise(time);

        DataRecorder.Initialise(time);

        var simulationSettingsString = SimulationSettings.ConvertToJsonString();
        var scenarioSettingsString = ScenarioSettings.ConvertToJsonString();
        var flightpathDemandString = FlightpathDemandList.FlightpathDemands.ConvertToJsonString();

        nextDisplayTime = ScenarioSettings.SimulationClockSettings.TimeStart;

        LogUtilities.LogInformation($"Simulation Settings {Environment.NewLine} {simulationSettingsString}");
        LogUtilities.LogInformation($"Scenario Settings {Environment.NewLine} {scenarioSettingsString}");
        LogUtilities.LogInformation($"Flightpath Demands {Environment.NewLine} {flightpathDemandString}");

        LogUtilities.LogInformation("Initialise Finished.");
        LogUtilities.LogInformation("");
    }

    public void Update(double time)
    {
        Scenario.Update(time);
    }

    public void Finalise(double time)
    {
        LogUtilities.LogInformation("Finalise Started...");
        LogUtilities.LogInformation("");

        Scenario.Finalise(time);

        var flightpathDataAll = GenerateFlightpathDataAll();

        DataRecorder.SimulationData.FlightpathStateDataAll = flightpathDataAll;

        DataRecorder.Finalise(time);

        LogUtilities.LogInformation("");
        LogUtilities.LogInformation("Finalise Finished.");
        LogUtilities.LogInformation("");
    }

    public void ShowProgress(double time)
    {
        var isDisplayTime = (time >= nextDisplayTime);

        if (isDisplayTime)
        {
            LogUtilities.LogInformation($"Time = {nextDisplayTime:000}s");

            displayCount++;
            nextDisplayTime = ScenarioSettings.SimulationClockSettings.TimeStart + displayCount * 5.0;
        }
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

        if (!DataRecorder.SimulationData.SimulationSettings.IsCreateZipFile)
        {
            return;
        }

        var zipFileName = $"{DataRecorder.SimulationData.SimulationSettings.SimulationName}.zip";

        var zipFileNameFull = DataRecorder.SimulationData.SimulationSettings.GetFileNameFull(zipFileName);

        var isCloseLog = true;

        ZipUtilities.ZipDirectory(DataRecorder.SimulationData.SimulationSettings.OutputFolder, zipFileNameFull, isCloseLog);
    }
}