using MissionEngineering.MathLibrary;

namespace MissionEngineering.ScenarioGenerator;

public record FlightpathSettings
{
    public int FlightpathId { get; init; }

    public string FlightpathName { get; init; } = string.Empty;

    public double TimeStart { get; init; }

    public double TimeEnd { get; init; }

    public double TimeStep { get; init; }

    public PositionNED PositionNED { get; init; }

    public VelocityNED VelocityNED { get; init; }
}