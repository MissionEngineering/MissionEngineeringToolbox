using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionEngineering.MathLibrary;

namespace MissionEngineering.ScenarioGenerator;

public class FlightpathAutopilot : IFlightpathAccelerationGenerator
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
