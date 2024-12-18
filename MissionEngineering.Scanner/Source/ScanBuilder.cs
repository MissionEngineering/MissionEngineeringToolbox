using Microsoft.Extensions.DependencyInjection;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner;

public static class ScanBuilder
{
    public static IScanGenerator CreateScanGenerator()
    {
        var services = new ServiceCollection();

        services.AddScoped<SimulationClockSettings, SimulationClockSettings>();
        services.AddScoped<ISimulationClock, SimulationClock>();
        services.AddScoped<ScanPatternDemand, ScanPatternDemand>();
        services.AddScoped<ScanDynamics, ScanDynamics>();
        services.AddScoped<IScanner, Scanner>();
        services.AddScoped<IScanGenerator, ScanGenerator>();
        services.AddScoped<IDateTimeOrigin, DateTimeOrigin>();
        services.AddScoped<ScanStateData, ScanStateData>();

        using var serviceProvider = services.BuildServiceProvider();

        var scanGenerator = serviceProvider.GetRequiredService<IScanGenerator>();

        return scanGenerator;
    }
}