using CommunityToolkit.Diagnostics;

namespace MissionEngineering.MathLibrary;

public class Interpolation1DSampleBefore : Interpolation1DBase
{
    public Interpolation1DSampleBefore(double[] x, double[] y)
    {
        Guard.IsGreaterThan(x.Length, 0);
        Guard.IsEqualTo(x.Length, y.Length);

        X = new Vector(x);
        Y = new Vector(y);

        (_xStart, _xEnd, _yStart, _yEnd, _xStep) = GetEndPoints();
    }

    public Interpolation1DSampleBefore(Vector x, Vector y) : this(x.Data, y.Data)
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

        var yi = 0.0;

        for (int i = 0; i < X.NumberOfElements - 1; i++)
        {
            if (xi >= X[i] && xi <= X[i + 1])
            {
                yi = Y[i];
                return yi;
            }
        }

        return yi;
    }
}