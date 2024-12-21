﻿namespace MissionEngineering.Scenario;

public class FlightpathDemandList : IFlightpathDemandList
{
    public List<FlightpathDemand> FlightpathDemands { get; set; }

    private double currentTime = -1.0;

    public List<FlightpathDemand> GetFlightpathDemands(double time)
    {
        var flightpathDemands = FlightpathDemands.Where(s => s.FlightpathDemandTime > currentTime && s.FlightpathDemandTime <= time).ToList();

        currentTime = time;

        return flightpathDemands;
    }
}