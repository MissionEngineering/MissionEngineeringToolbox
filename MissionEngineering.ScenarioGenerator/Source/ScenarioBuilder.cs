using Microsoft.Extensions.DependencyInjection;
using MissionEngineering.DataRecorder;
using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public static class ScenarioBuilder
{
    public static IScenarioGenerator CreateScenarioGenerator()
    {
        var services = new ServiceCollection();

        services.AddScoped<IScenarioGenerator, ScenarioGenerator>();
        services.AddScoped<IDateTimeOrigin, DateTimeOrigin>();
        services.AddScoped<ILLAOrigin, LLAOrigin>();
        services.AddScoped<ISimulationClock, SimulationClock>();
        services.AddScoped<IScenario, Scenario.Scenario>();
        services.AddScoped<ScenarioSettings, ScenarioSettings>();
        services.AddScoped<IDataRecorder, DataRecorder.DataRecorder>();
        services.AddScoped<SimulationSettings, SimulationSettings>();
        services.AddScoped<SimulationData, SimulationData>();

        using var serviceProvider = services.BuildServiceProvider();

        var scenarioGenerator = serviceProvider.GetRequiredService<IScenarioGenerator>();

        return scenarioGenerator;
    }
}