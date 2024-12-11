using MissionEngineering.Core;

namespace MissionEngineering.ScenarioGenerator;

public class Program
{
    public static string ScenarioSettingsFileName { get; set; }

    public static string OutputPath { get; set; }

    public static ScenarioSettings ScenarioSettings { get; set; }

    public static IScenarioGenerator ScenarioGenerator { get; set; }

    /// <summary>
    /// Scenario Generator.
    /// </summary>
    /// <param name="scenarioSettingsFileName">Scenario Settings File Name</param>
    /// <param name="outputPath">Output Path</param>
    public static void Main(string scenarioSettingsFileName = "", string outputPath = @"c:\temp\MissionEngineeringToolbox")
    {
        ScenarioSettingsFileName = scenarioSettingsFileName;
        OutputPath = outputPath;

        Run();

        WriteData();
    }

    private static void Run()
    {
        GenerateScenarioSettings();

        ScenarioGenerator = ScenarioBuilder.CreateScenarioGenerator();

        ScenarioGenerator.ScenarioSettings = ScenarioSettings;

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

    private static void WriteData()
    {
        ScenarioGenerator.WriteToCsv(OutputPath);

        var jsonFileName = "ScenarioSettingsFileName" + ".json";

        var fileName = Path.Combine(OutputPath, jsonFileName);

        if (string.IsNullOrEmpty(ScenarioSettingsFileName))
        {
            ScenarioSettings.WriteToJsonFile(fileName);
        }
    }
}