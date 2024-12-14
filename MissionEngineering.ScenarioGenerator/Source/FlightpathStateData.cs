using System.Diagnostics.CodeAnalysis;
using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation;

namespace MissionEngineering.ScenarioGenerator;

public record FlightpathStateData
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

    [SetsRequiredMembers]
    public FlightpathStateData()
    {
        FlightpathId = 0;
        FlightpathName = "";
        TimeStamp = new TimeStamp();
        PositionLLA = new PositionLLA(0.0, 0.0, 0.0);
        PositionNED = new PositionNED(0.0, 0.0, 0.0);
        VelocityNED = new VelocityNED(0.0, 0.0, 0.0);
        AccelerationNED = new AccelerationNED(0.0, 0.0, 0.0);
        AccelerationTBA = new AccelerationTBA(0.0, 0.0, 0.0);
        Attitude = new Attitude(0.0, 0.0, 0.0);
        AttitudeRate = new AttitudeRate(0.0, 0.0, 0.0);
    }
}