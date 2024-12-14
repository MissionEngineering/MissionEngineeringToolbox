using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner;

public class ScanGenerator : IScanGenerator
{
    public IScanner Scanner { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public SimulationClockSettings SimulationClockSettings { get; set; }

    public ScanGenerator(IScanner scanner, ISimulationClock simulationClock, SimulationClockSettings simulationClockSettings)
    {
        Scanner = scanner;
        SimulationClock = simulationClock;
        SimulationClockSettings = simulationClockSettings;
    }

    public void Run()
    {
        var clockSettings = SimulationClockSettings;

        var time = clockSettings.TimeStart;

        Initialise(time);

        while (time <= clockSettings.TimeEnd)
        {
            Update(time);

            time += clockSettings.TimeStep;
        }

        Finalise(time);
    }

    public void Initialise(double time)
    {
        SimulationClock.DateTimeOrigin.DateTime = SimulationClockSettings.DateTimeOrigin;

        Scanner.Initialise(time);
    }

    public void Update(double time)
    {
        Scanner.Update(time);
    }

    public void Finalise(double time)
    {
        Scanner.Finalise(time);
    }
}