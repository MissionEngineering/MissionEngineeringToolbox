
namespace MissionEngineering.Scenario
{
    public interface IFlightpathDemandList
    {
        List<FlightpathDemand> FlightpathDemands { get; set; }

        List<FlightpathDemand> GetFlightpathDemands(double time);
    }
}