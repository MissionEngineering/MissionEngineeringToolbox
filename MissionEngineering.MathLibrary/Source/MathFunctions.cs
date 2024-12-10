namespace MissionEngineering.MathLibrary;

public static class MathFunctions
{
    public static double ConstrainAngle0To360(double x)
    {
        var result = x;

        if (x > 360.0)
        {
            result -= 360.0;
        }

        if (x < 0.0)
        {
            result += 360.0;
        }

        return result;
    }

    public static double ConstrainAnglePlusMinus180(double x)
    {
        var result = x;

        if (x > 180.0)
        {
            result -= 360.0;
        }

        if (x < -180.0)
        {
            result += 360.0;
        }

        return result;
    }
}