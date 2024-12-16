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
            var flightpathAccelerationGenerator = new FlightpathAutopilot();

            var flightpath = new Flightpath(SimulationClock, LLAOrigin)
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
}