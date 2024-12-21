using MissionEngineering.Core;
using MissionEngineering.Scenario;

namespace MissionEngineering.ScenarioGenerator;

public class Program
{
    public static string ScenarioSettingsFileName { get; set; }

    public static ScenarioSettings ScenarioSettings { get; set; }

    public static IScenarioGenerator ScenarioGenerator { get; set; }

    /// <summary>
    /// Scenario Generator.
    /// </summary>
    /// <param name="scenarioSettingsFileName">Scenario Settings File Name</param>
    public static void Main(string scenarioSettingsFileName = "")
    {
        ScenarioSettingsFileName = scenarioSettingsFileName;

        Run();
    }

    private static void Run()
    {
        GenerateScenarioSettings();

        ScenarioGenerator = ScenarioBuilder.CreateScenarioGenerator();

        ScenarioGenerator.ScenarioSettings = ScenarioSettings;

        LogUtilities.CreateLogger(ScenarioGenerator.DataRecorder.SimulationData.SimulationSettings.LogFileName);

        ScenarioGenerator.Run();
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