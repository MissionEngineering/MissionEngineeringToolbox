namespace MissionEngineering.MathLibrary;

public abstract class Interpolation1DBase : IInterpolation1D
{
    public Vector X { get; init; }

    public Vector Y { get; init; }

    protected double _xStart { get; init; }

    protected double _xEnd { get; init; }

    protected double _yStart { get; init; }

    protected double _yEnd { get; init; }

    protected double _xStep { get; init; }

    public abstract double Interpolate(double xi);

    public double[] Interpolate(double[] xi)
    {
        var yi = new double[xi.Length];

        for (var i = 0; i < xi.Length; i++)
        {
            yi[i] = Interpolate(xi[i]);
        }

        return yi;
    }

    public Vector Interpolate(Vector xi)
    {
        var yi = Interpolate(xi.Data);

        var result = new Vector(yi);

        return result;
    }

    public (double xStart, double xEnd, double yStart, double yEnd, double xStep) GetEndPoints()
    {
        var xStart = X[0];
        var xEnd = X[^1];
        var yStart = Y[0];
        var yEnd = Y[^1];

        var numberOfElements = X.NumberOfElements;

        var xStep = 1.0;

        if (numberOfElements > 1)
        {
            xStep = (xEnd - xStart) / (X.NumberOfElements - 1);
        }

        return (xStart, xEnd, yStart, yEnd, xStep);
    }
}