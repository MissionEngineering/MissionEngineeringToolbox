using MissionEngineering.Scenario;

namespace MissionEngineering.Simulation;

public static class FlightpathDemandFactory
{
    public static List<FlightpathDemand> FlightpathDemands_Test_1()
    {
        var fd1 = new FlightpathDemand()
        {
            FlightpathDemandFlightpathId = 1,
            FlightpathDemandModificationId = 1,
            FlightpathDemandTime = 20.0,
            HeadingAngleDemandDeg = 45.0,
            TotalSpeedDemand = 300.0,
            AltitudeDemand = 9000.0
        };

        var fd2 = new FlightpathDemand()
        {
            FlightpathDemandFlightpathId = 1,
            FlightpathDemandModificationId = 2,
            FlightpathDemandTime = 120.0,
            HeadingAngleDemandDeg = -135,
            TotalSpeedDemand = 200.0,
            AltitudeDemand = 6000.0
        };

        var fd3 = new FlightpathDemand()
        {
            FlightpathDemandFlightpathId = 2,
            FlightpathDemandModificationId = 1,
            FlightpathDemandTime = 30.0,
            HeadingAngleDemandDeg = -90,
            TotalSpeedDemand = 200.0,
            AltitudeDemand = 6000.0
        };

        var fd4 = new FlightpathDemand()
        {
            FlightpathDemandFlightpathId = 2,
            FlightpathDemandModificationId = 2,
            FlightpathDemandTime = 130.0,
            HeadingAngleDemandDeg = 30.0,
            TotalSpeedDemand = 200.0,
            AltitudeDemand = 6000.0
        };

        var flightpathDemands = new List<FlightpathDemand> { fd1, fd2, fd3, fd4 };

        return flightpathDemands;
    }
}