using MissionEngineering.MathLibrary;

namespace MissionEngineering.ScenarioGenerator;

public class FlightpathAutopilot
{
    public FlightpathDemand FlightpathDemand { get; set; }

    public FlightpathData FlightpathData { get; set; }

    public FlightpathAutopilot()
    {
        FlightpathDemand = new FlightpathDemand();
        FlightpathData = new FlightpathData();
    }

    public AccelerationTBA GetAccelerationTBA(double time)
    {
        var accelerationTBA = new AccelerationTBA();

        return accelerationTBA;
    }
}