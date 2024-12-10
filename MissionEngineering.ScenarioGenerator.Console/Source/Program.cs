using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public class Program
{
    public static string ScenarioSettingsFileName { get; set; }

    public static string OutputPath { get; set; }

    public static ScenarioSettings ScenarioSettings { get; set; }

    public static IScenarioGenerator ScenarioGenerator {  get; set; }

    /// <summary>
    /// Scenario Settings File Name.
    /// </summary>
    /// <param name="scenarioSettingsFileName"></param>
    /// <param name="outputPath"></param>
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
        ScenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();
    }

    private static void WriteData()
    {
        ScenarioGenerator.WriteToCsv(OutputPath);
    }
}
