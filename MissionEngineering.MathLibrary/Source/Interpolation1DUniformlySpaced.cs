using CommunityToolkit.Diagnostics;

namespace MissionEngineering.MathLibrary;

public class Interpolation1DUniformlySpaced : Interpolation1DBase
{
    public Interpolation1DUniformlySpaced(double[] x, double[] y)
    {
        Guard.IsGreaterThan(x.Length, 0);
        Guard.IsEqualTo(x.Length, y.Length);

        X = new Vector(x);
        Y = new Vector(y);

        (_xStart, _xEnd, _yStart, _yEnd, _xStep) = GetEndPoints();
    }

    public Interpolation1DUniformlySpaced(Vector x, Vector y) : this(x.Data, y.Data)
    {
    }

    public override double Interpolate(double xi)
    {
        if (xi <= _xStart)
        {
            return _yStart;
        }
        else if (xi >= _xEnd)
        {
            return _yEnd;
        }

        var xIndex = (int)((xi - _xStart) / _xStep);

        var x0 = X[xIndex];
        var x1 = X[xIndex + 1];

        var y0 = Y[xIndex];
        var y1 = Y[xIndex + 1];

        var yi = LinearInterpolate(x0, x1, y0, y1, xi);

        return yi;
    }

    private double LinearInterpolate(double x0, double x1, double y0, double y1, double xi)
    {
        var yi = (y0 * (x1 - xi) + y1 * (xi - x0)) / _xStep;

        return yi;
    }
}