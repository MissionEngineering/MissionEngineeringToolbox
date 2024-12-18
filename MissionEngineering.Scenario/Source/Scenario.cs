using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scenario;

public class Scenario : IScenario, IExecutableModel
{
    public ScenarioSettings ScenarioSettings { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public List<Flightpath> FlightpathList { get; set; }

    public int NumberOfFlightpaths => ScenarioSettings.FlightpathSettingsList.Count;

    public Scenario(ScenarioSettings scenarioSettings, ISimulationClock simulationClock, ILLAOrigin llaOrigin)
    {
        ScenarioSettings = scenarioSettings;
        SimulationClock = simulationClock;
        LLAOrigin = llaOrigin;

        FlightpathList = new List<Flightpath>();
    }

    public void Initialise(double time)
    {
        FlightpathList = new List<Flightpath>(NumberOfFlightpaths);

        foreach (var flightpathSettings in ScenarioSettings.FlightpathSettingsList)
        {
            var flightpathDynamics = new FlightpathDynamics();

            var flightpathAutopilot = new FlightpathAutopilot(flightpathDynamics);

            var flightpath = new Flightpath(SimulationClock, LLAOrigin, flightpathAutopilot)
            {
                FlightpathSettings = flightpathSettings
            };

            flightpath.Initialise(time);

            FlightpathList.Add(flightpath);
        }
    }

    public void Update(double time)
    {
        foreach (var flightpath in FlightpathList)
        {
            var flightpathDemand = GetFlightpathDemand(flightpath, time);

            if (flightpathDemand != null)
            {
                flightpath.SetFlightpathDemand(flightpathDemand);
            }

            flightpath.Update(time);
        }
    }

    public void Finalise(double time)
    {
        foreach (var flightpath in FlightpathList)
        {
            flightpath.Finalise(time);
        }
    }

    public FlightpathDemand GetFlightpathDemand(Flightpath flightpath, double time)
    {
        FlightpathDemand flightpathDemand = null;

        if (time > 20.0)
        {
            flightpathDemand = new FlightpathDemand()
            {
                FlightpathDemandFlightpathId = flightpath.FlightpathSettings.FlightpathId,
                FlightpathDemandModificationId = 1,
                FlightpathDemandTime = time,
                HeadingAngleDemandDeg = 45.0,
                TotalSpeedDemand = 300.0,
                AltitudeDemand = 9000.0
            };
        }

        if (time > 120.0)
        {
            flightpathDemand = new FlightpathDemand()
            {
                FlightpathDemandFlightpathId = flightpath.FlightpathSettings.FlightpathId,
                FlightpathDemandModificationId = 2,
                FlightpathDemandTime = time,
                HeadingAngleDemandDeg = -135,
                TotalSpeedDemand = 200.0,
                AltitudeDemand = 6000.0
            };
        }

        return flightpathDemand;
    }
}