namespace MissionEngineering.ScenarioGenerator;

public interface IScenario
{
    ScenarioSettings ScenarioSettings { get; set; }

    List<Flightpath> FlightpathList { get; set; }

    int NumberOfFlightpaths { get; }

    void Initialise(double time);

    void Update(double time);

    void Finalise(double time);
}