using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation;

namespace MissionEngineering.Scenario;

public record FlightpathStateData
{
    public int FlightpathId { get; init; }

    public string FlightpathName { get; init; }

    public SimulationTimeStamp TimeStamp { get; init; }

    public PositionLLA PositionLLA { get; init; }

    public PositionNED PositionNED { get; init; }

    public VelocityNED VelocityNED { get; init; }

    public AccelerationNED AccelerationNED { get; init; }

    public AccelerationTBA AccelerationTBA { get; init; }

    public Attitude Attitude { get; init; }

    public AttitudeRate AttitudeRate { get; init; }

    public FlightpathDemand FlightpathDemand { get; set; }

    public FlightpathStateData()
    {
    }
}