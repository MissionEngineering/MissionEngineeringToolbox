﻿namespace MissionEngineering.MathLibrary;

public record VelocityNED
{
    public double VelocityNorth { get; init; }

    public double VelocityEast { get; init; }

    public double VelocityDown { get; init; }

    public VelocityNED(double velocityNorth, double velocityEast, double velocityDown)
    {
        VelocityNorth = velocityNorth;
        VelocityEast = velocityEast;
        VelocityDown = velocityDown;
    }

    public static VelocityNED operator +(VelocityNED left, VelocityNED right)
    {
        var velocityNorth = left.VelocityNorth + right.VelocityNorth;
        var velocityEast = left.VelocityEast + right.VelocityEast;
        var velocityDown = left.VelocityDown + right.VelocityDown;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }

    public static VelocityNED operator -(VelocityNED left)
    {
        var velocityNorth = -left.VelocityNorth;
        var velocityEast = -left.VelocityEast;
        var velocityDown = -left.VelocityDown;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }

    public static VelocityNED operator -(VelocityNED left, VelocityNED right)
    {
        var velocityNorth = left.VelocityNorth - right.VelocityNorth;
        var velocityEast = left.VelocityEast - right.VelocityEast;
        var velocityDown = left.VelocityDown - right.VelocityDown;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }

    public static VelocityNED operator *(VelocityNED left, double right)
    {
        var velocityNorth = left.VelocityNorth * right;
        var velocityEast = left.VelocityEast * right;
        var velocityDown = left.VelocityDown * right;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }

    public static VelocityNED operator *(double left, VelocityNED right)
    {
        var velocityNorth = left * right.VelocityNorth;
        var velocityEast = left * right.VelocityEast;
        var velocityDown = left * right.VelocityDown;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }

    public static VelocityNED operator /(VelocityNED left, double right)
    {
        var velocityNorth = left.VelocityNorth / right;
        var velocityEast = left.VelocityEast / right;
        var velocityDown = left.VelocityDown / right;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }

    public static VelocityNED operator /(double left, VelocityNED right)
    {
        var velocityNorth = left / right.VelocityNorth;
        var velocityEast = left / right.VelocityEast;
        var velocityDown = left / right.VelocityDown;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }
}