namespace MissionEngineering.MathLibrary;

public record AccelerationNED
{
    public double AccelerationNorth { get; init; }

    public double AccelerationEast { get; init; }

    public double AccelerationDown { get; init; }

    public AccelerationNED(double accelerationNorth, double accelerationEast, double accelerationDown)
    {
        AccelerationNorth = accelerationNorth;
        AccelerationEast = accelerationEast;
        AccelerationDown = accelerationDown;
    }

    public static AccelerationNED operator +(AccelerationNED left, AccelerationNED right)
    {
        var accelerationNorth = left.AccelerationNorth + right.AccelerationNorth;
        var accelerationEast = left.AccelerationEast + right.AccelerationEast;
        var accelerationDown = left.AccelerationDown + right.AccelerationDown;

        var result = new AccelerationNED(accelerationNorth, accelerationEast, accelerationDown);

        return result;
    }

    public static AccelerationNED operator -(AccelerationNED left)
    {
        var accelerationNorth = -left.AccelerationNorth;
        var accelerationEast = -left.AccelerationEast;
        var accelerationDown = -left.AccelerationDown;

        var result = new AccelerationNED(accelerationNorth, accelerationEast, accelerationDown);

        return result;
    }

    public static AccelerationNED operator -(AccelerationNED left, AccelerationNED right)
    {
        var accelerationNorth = left.AccelerationNorth - right.AccelerationNorth;
        var accelerationEast = left.AccelerationEast - right.AccelerationEast;
        var accelerationDown = left.AccelerationDown - right.AccelerationDown;

        var result = new AccelerationNED(accelerationNorth, accelerationEast, accelerationDown);

        return result;
    }

    public static AccelerationNED operator *(AccelerationNED left, double right)
    {
        var accelerationNorth = left.AccelerationNorth * right;
        var accelerationEast = left.AccelerationEast * right;
        var accelerationDown = left.AccelerationDown * right;

        var result = new AccelerationNED(accelerationNorth, accelerationEast, accelerationDown);

        return result;
    }

    public static AccelerationNED operator *(double left, AccelerationNED right)
    {
        var accelerationNorth = left * right.AccelerationNorth;
        var accelerationEast = left * right.AccelerationEast;
        var accelerationDown = left * right.AccelerationDown;

        var result = new AccelerationNED(accelerationNorth, accelerationEast, accelerationDown);

        return result;
    }

    public static AccelerationNED operator /(AccelerationNED left, double right)
    {
        var accelerationNorth = left.AccelerationNorth / right;
        var accelerationEast = left.AccelerationEast / right;
        var accelerationDown = left.AccelerationDown / right;

        var result = new AccelerationNED(accelerationNorth, accelerationEast, accelerationDown);

        return result;
    }

    public static AccelerationNED operator /(double left, AccelerationNED right)
    {
        var accelerationNorth = left / right.AccelerationNorth;
        var accelerationEast = left / right.AccelerationEast;
        var accelerationDown = left / right.AccelerationDown;

        var result = new AccelerationNED(accelerationNorth, accelerationEast, accelerationDown);

        return result;
    }
}