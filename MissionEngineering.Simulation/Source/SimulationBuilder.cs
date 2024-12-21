using Microsoft.Extensions.DependencyInjection;
using MissionEngineering.DataRecorder;
using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.SimdisLibrary;
using MissionEngineering.Simulation;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public static class SimulationBuilder
{
    public static ISimulationHarness CreateSimulationHarness()
    {
        var services = new ServiceCollection();

        services.AddScoped<ISimulationHarness, SimulationHarness>();
        services.AddScoped<SimulationHarnessSettings, SimulationHarnessSettings>();
        services.AddScoped<ISimulation, Simulation.Simulation>();
        services.AddScoped<IDateTimeOrigin, DateTimeOrigin>();
        services.AddScoped<ILLAOrigin, LLAOrigin>();
        services.AddScoped<ISimulationClock, SimulationClock>();
        services.AddScoped<IScenario, Scenario.Scenario>();
        services.AddScoped<ScenarioSettings, ScenarioSettings>();
        services.AddScoped<IDataRecorder, DataRecorder.DataRecorder>();
        services.AddScoped<SimulationSettings, SimulationSettings>();
        services.AddScoped<SimulationData, SimulationData>();
        services.AddScoped<ISimdisExporter, SimdisExporter>();

        using var serviceProvider = services.BuildServiceProvider();

        var simulationHarness = serviceProvider.GetRequiredService<ISimulationHarness>();

        return simulationHarness;
    }

    public static ISimulation CreateSimulation()
    {
        var services = new ServiceCollection();

        services.AddScoped<ISimulation, Simulation.Simulation>();
        services.AddScoped<IDateTimeOrigin, DateTimeOrigin>();
        services.AddScoped<ILLAOrigin, LLAOrigin>();
        services.AddScoped<ISimulationClock, SimulationClock>();
        services.AddScoped<IScenario, Scenario.Scenario>();
        services.AddScoped<ScenarioSettings, ScenarioSettings>();
        services.AddScoped<IDataRecorder, DataRecorder.DataRecorder>();
        services.AddScoped<SimulationSettings, SimulationSettings>();
        services.AddScoped<SimulationData, SimulationData>();
        services.AddScoped<ISimdisExporter, SimdisExporter>();

        using var serviceProvider = services.BuildServiceProvider();

        var simulation = serviceProvider.GetRequiredService<ISimulation>();

        return simulation;
    }

    public static IScenario CreateScenario()
    {
        var services = new ServiceCollection();

        services.AddScoped<IDateTimeOrigin, DateTimeOrigin>();
        services.AddScoped<ILLAOrigin, LLAOrigin>();
        services.AddScoped<ISimulationClock, SimulationClock>();
        services.AddScoped<IScenario, Scenario.Scenario>();
        services.AddScoped<ScenarioSettings, ScenarioSettings>();
        services.AddScoped<IDataRecorder, DataRecorder.DataRecorder>();
        services.AddScoped<SimulationSettings, SimulationSettings>();
        services.AddScoped<SimulationData, SimulationData>();
        services.AddScoped<ISimdisExporter, SimdisExporter>();

        using var serviceProvider = services.BuildServiceProvider();

        var scenario = serviceProvider.GetRequiredService<IScenario>();

        return scenario;
    }
}