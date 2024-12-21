using MissionEngineering.Core;
using MissionEngineering.Scenario;
using MissionEngineering.ScenarioGenerator;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

public class Program
{
    public static string SimulationSettingsFileName { get; set; }

    public static string ScenarioSettingsFileName { get; set; }

    public static int NumberOfRuns {  get; set; }

    public static SimulationSettings SimulationSettings { get; set; }

    public static ScenarioSettings ScenarioSettings { get; set; }

    public static ISimulationHarness SimulationHarness { get; set; }

    /// <summary>
    /// Simulation Console Runner.
    /// </summary>
    /// <param name="simulationSettingsFileName">Simulation Settings File Name</param>
    /// <param name="scenarioSettingsFileName">Scenario Settings File Name</param>
    /// <param name="numberOfRuns">Number Of Runs</param>
    public static void Main(string simulationSettingsFileName, string scenarioSettingsFileName, int numberOfRuns = 10)
    {
        SimulationSettingsFileName = simulationSettingsFileName;
        ScenarioSettingsFileName = scenarioSettingsFileName;
        NumberOfRuns = numberOfRuns;

        Run();
    }

    private static void Run()
    {
        GenerateSimulationSettings();
        GenerateScenarioSettings();

        SimulationHarness = SimulationBuilder.CreateSimulationHarness();

        SimulationHarness.SimulationSettings = SimulationSettings;
        SimulationHarness.ScenarioSettings = ScenarioSettings;
        SimulationHarness.SimulationHarnessSettings.NumberOfRuns = NumberOfRuns;

        SimulationHarness.Run();
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