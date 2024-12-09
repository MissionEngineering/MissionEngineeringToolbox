namespace MissionEngineering.MathLibrary;

public record PositionNED
{
    public double PositionNorth { get; init; }

    public double PositionEast { get; init; }

    public double PositionDown { get; init; }

    public PositionNED(double positionNorth, double positionEast, double positionDown)
    {
        PositionNorth = positionNorth;
        PositionEast = positionEast;
        PositionDown = positionDown;
    }
}