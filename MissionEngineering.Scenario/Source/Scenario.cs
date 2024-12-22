using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scenario;

public class Scenario : IScenario, IExecutableModel
{
    public ScenarioSettings ScenarioSettings { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public IFlightpathDemandList FlightpathDemandList { get; set; }

    public List<Flightpath> FlightpathList { get; set; }

    public Dictionary<int, Flightpath> FlightpathDictionary { get; set; }

    public int NumberOfFlightpaths => ScenarioSettings.FlightpathSettingsList.Count;

    public Scenario(ScenarioSettings scenarioSettings, ISimulationClock simulationClock, ILLAOrigin llaOrigin, IFlightpathDemandList flightpathDemandList)
    {
        ScenarioSettings = scenarioSettings;
        SimulationClock = simulationClock;
        LLAOrigin = llaOrigin;
        FlightpathDemandList = flightpathDemandList;
    }

    public void Initialise(double time)
    {
        FlightpathList = new List<Flightpath>(NumberOfFlightpaths);

        FlightpathDictionary = [];

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

            FlightpathDictionary.Add(flightpath.FlightpathSettings.FlightpathId, flightpath);
        }
    }

    public void Update(double time)
    {
        ProcessFlightpathDemands(time);

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

    public void ProcessFlightpathDemands(double time)
    {
        var flightpathDemands = FlightpathDemandList.GetFlightpathDemands(time);

        foreach (var flightpathDemand in flightpathDemands)
        {
            var flightpath = FlightpathDictionary[flightpathDemand.FlightpathDemandFlightpathId];

            flightpath.SetFlightpathDemand(flightpathDemand);
        }
    }
}