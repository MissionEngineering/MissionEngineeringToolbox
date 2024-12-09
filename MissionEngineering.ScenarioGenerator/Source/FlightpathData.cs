using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation;

namespace MissionEngineering.ScenarioGenerator;

public record FlightpathData
{
    public required int FlightpathId { get; init; }

    public required string FlightpathName { get; init; }

    public required TimeStamp TimeStamp { get; init; }

    public required PositionLLA PositionLLA { get; init; }

    public required PositionNED PositionNED { get; init; }

    public required VelocityNED VelocityNED { get; init; }

    public required AccelerationNED AccelerationNED { get; init; }

    public required AccelerationTBA AccelerationTBA { get; init; }

    public required Attitude Attitude { get; init; }

    public required AttitudeRate AttitudeRate { get; init; }
}