namespace MissionEngineering.Scenario;

public interface IScenario
{
    ScenarioSettings ScenarioSettings { get; set; }

    List<Flightpath> FlightpathList { get; set; }

    IFlightpathDemandList FlightpathDemandList { get; set; }

    int NumberOfFlightpaths { get; }

    void Initialise(double time);

    void Update(double time);

    void Finalise(double time);
}