using CommunityToolkit.Diagnostics;

namespace MissionEngineering.MathLibrary;

public class Interpolation1D
{
    public double[] X { get; init; }

    public double[] Y { get; init; }

    public double XStart { get; init; }

    public double XEnd { get; init; }

    public double YStart { get; init; }

    public double YEnd { get; init; }

    public Interpolation1D(double[] x, double[] y)
    {
        Guard.IsGreaterThan(x.Length, 0);
        Guard.IsEqualTo(x.Length, y.Length);

        X = x;
        Y = y;

        XStart = X[0];
        XEnd = X[^1];

        YStart = Y[0];
        YEnd = Y[^1];
    }

    public Interpolation1D(Vector x, Vector y) : this(x.Data, y.Data)
    {
    }

    public double Interpolate(double xi)
    {
        var yi = Y[0];

        return yi;
    }

    public double[] Interpolate(double[] xi)
    {
        var data = new double[xi.Length];

        for (int i = 0; i < xi.Length; i++)
        {
            data[i] = Interpolate(xi[i]);
        }

        return data;
    }

    public Vector Interpolate(Vector xi)
    {
        var yiArray = Interpolate(xi.Data);

        var yi = new Vector(yiArray);

        return yi;
    }
}