namespace MissionEngineering.MathLibrary;

public class Matrix
{
    public int NumberOfRows => Data.GetLength(0);

    public int NumberOfColumns => Data.GetLength(1);

    public double[,] Data { get; set; }

    public Matrix() : this(0, 0)
    {
    }

    public Matrix(int numberOfRows, int numberOfColumns)
    {
        Data = new double[numberOfRows, numberOfColumns];
    }

    public Matrix(double[,] data)
    {
        Data = data;
    }

    public double this[int rowIndex, int columnIndex]
    {
        get => Data[rowIndex, columnIndex];
        set => Data[rowIndex, columnIndex] = value;
    }
}