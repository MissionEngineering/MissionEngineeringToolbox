using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public class FlightpathGenerator
{
    public FlightpathSettings FlightpathSettings { get; set; }

    public SimulationClockSettings SimulationClockSettings { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public Flightpath Flightpath { get; set; }

    public FlightpathGenerator(SimulationClockSettings simulationClockSettings, ILLAOrigin llaOrigin)
    {
        SimulationClockSettings = simulationClockSettings;
        LLAOrigin = llaOrigin;
    }

    public void Run()
    {
        var time = SimulationClockSettings.TimeStart;

        Initialise(time);

        while (time <= SimulationClockSettings.TimeEnd)
        {
            Update(time);

            time += SimulationClockSettings.TimeStep;
        }

        Finalise(time);
    }

    public void Initialise(double time)
    {
        var dateTimeOrigin = new DateTimeOrigin() { DateTime = SimulationClockSettings.DateTimeOrigin };

        SimulationClock = new SimulationClock(dateTimeOrigin);

        var flightpathDynamics = new FlightpathDynamics();

        var flightpathAutoPilot = new FlightpathAutopilot(flightpathDynamics);

        Flightpath = new Flightpath(SimulationClock, LLAOrigin, flightpathAutoPilot)
        {
            FlightpathSettings = FlightpathSettings
        };

        Flightpath.Initialise(time);
    }

    public void Update(double time)
    {
        Flightpath.Update(time);
    }

    public void Finalise(double time)
    {
        Flightpath.Finalise(time);
    }
}