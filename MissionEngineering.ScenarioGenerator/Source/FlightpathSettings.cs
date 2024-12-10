using MissionEngineering.MathLibrary;

namespace MissionEngineering.ScenarioGenerator;

public record FlightpathSettings
{
    public int FlightpathId { get; init; }

    public string FlightpathName { get; init; } = string.Empty;

    public PositionNED PositionNED { get; init; }

    public VelocityNED VelocityNED { get; init; }
}