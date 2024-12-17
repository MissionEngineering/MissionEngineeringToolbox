namespace MissionEngineering.MathLibrary;

public partial class Matrix
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

    public Matrix Transpose()
    {
        var data = new double[NumberOfColumns, NumberOfRows];

        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                data[i, j] = Data[j, i];
            }
        }

        var result = new Matrix(data);

        return result;
    }
}