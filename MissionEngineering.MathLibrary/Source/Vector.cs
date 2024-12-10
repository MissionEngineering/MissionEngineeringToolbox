namespace MissionEngineering.MathLibrary;

public class Vector
{
    public int NumberOfElements => Data.Length;

    public double[] Data { get; set; }

    public Vector() : this(0)
    {
    }

    public Vector(int numberOfElements)
    {
        Data = new double[numberOfElements];
    }

    public Vector(params double[] data)
    {
        Data = data;
    }

    public Vector(params IEnumerable<double> data)
    {
        Data = data.ToArray();
    }

    public double this[int index]
    {
        get => Data[index];
        set => Data[index] = value;
    }
}