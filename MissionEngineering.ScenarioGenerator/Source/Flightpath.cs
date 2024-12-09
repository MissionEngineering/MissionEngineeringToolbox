namespace MissionEngineering.ScenarioGenerator;

public class Flightpath
{
    public FlightpathSettings FlightpathSettings { get; set; }

    public FlightpathData FlightpathData { get; set; }

    public List<FlightpathData> FlightpathDataList { get; set; }

    public Flightpath()
    {
        FlightpathSettings = new FlightpathSettings();
        FlightpathData = new FlightpathData();
        FlightpathDataList = new List<FlightpathData>();
    }

    public void Run()
    {
        var time = FlightpathSettings.TimeStart;

        Initialise(time);

        while (time <= FlightpathSettings.TimeEnd)
        {
            Update(time);

            time += FlightpathSettings.TimeStep;
        }

        Finalise(time);
    }

    public void Initialise(double time)
    {
        FlightpathData = new FlightpathData()
        {
            FlightpathId = FlightpathSettings.FlightpathId,
            FlightpathName = FlightpathSettings.FlightpathName,
            TimeStamp = new Simulation.TimeStamp() { SimulationTime = time }
        };
    }

    public void Update(double time)
    {
        FlightpathData = FlightpathData with { TimeStamp = new Simulation.TimeStamp() { SimulationTime = time } };

        FlightpathDataList.Add(FlightpathData);
    }

    public void Finalise(double time)
    {
    }
}