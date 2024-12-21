using MissionEngineering.Core;
using MissionEngineering.Scenario;
using MissionEngineering.ScenarioGenerator;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

public class Program
{
    public static string SimulationSettingsFileName { get; set; }

    public static string ScenarioSettingsFileName { get; set; }

    public static SimulationSettings SimulationSettings { get; set; }

    public static ScenarioSettings ScenarioSettings { get; set; }

    public static ISimulation Simulation { get; set; }

    /// <summary>
    /// Scenario Generator.
    /// </summary>
    /// <param name="simulationSettingsFileName">Simulation Settings File Name</param>
    /// <param name="scenarioSettingsFileName">Scenario Settings File Name</param>
    public static void Main(string simulationSettingsFileName, string scenarioSettingsFileName)
    {
        SimulationSettingsFileName = simulationSettingsFileName;
        ScenarioSettingsFileName = scenarioSettingsFileName;

        Run();
    }

    private static void Run()
    {
        GenerateSimulationSettings();
        GenerateScenarioSettings();

        Simulation = SimulationBuilder.CreateSimulation();

        Simulation.SimulationSettings = SimulationSettings;
        Simulation.ScenarioSettings = ScenarioSettings;

        LogUtilities.CreateLogger(Simulation.DataRecorder.SimulationData.SimulationSettings.LogFileName);

        Simulation.Run();
    }

    private static void GenerateSimulationSettings()
    {
        if (string.IsNullOrEmpty(SimulationSettingsFileName))
        {
            SimulationSettings = SimulationSettingsFactory.SimulationSettings_Test_1();
            return;
        }

        SimulationSettings = JsonUtilities.ReadFromJsonFile<SimulationSettings>(SimulationSettingsFileName);
    }

    private static void GenerateScenarioSettings()
    {
        if (string.IsNullOrEmpty(ScenarioSettingsFileName))
        {
            ScenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();
            return;
        }

        ScenarioSettings = JsonUtilities.ReadFromJsonFile<ScenarioSettings>(ScenarioSettingsFileName);
    }
}