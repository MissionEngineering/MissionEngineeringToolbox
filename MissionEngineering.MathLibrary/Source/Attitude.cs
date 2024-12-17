using static System.Math;

namespace MissionEngineering.MathLibrary;

public record Attitude
{
    public double HeadingAngleDeg { get; init; }

    public double PitchAngleDeg { get; init; }

    public double BankAngleDeg { get; init; }

    public Attitude()
    {
    }

    public Attitude(double headingAngleDeg, double pitchAngleDeg, double bankAngleDeg)
    {
        HeadingAngleDeg = headingAngleDeg;
        PitchAngleDeg = pitchAngleDeg;
        BankAngleDeg = bankAngleDeg;
    }

    public Matrix GetTransformationMatrix()
    {
        var t1 = CalculateTransformationMatrixHeading();
        var t2 = CalculateTransformationMatrixPitch();
        var t3 = CalculateTransformationMatrixBank();

        var t = t3 * t2 * t1;

        return t;
    }

    public Matrix CalculateTransformationMatrixHeading()
    {
        var headingAngle = HeadingAngleDeg.DegreesToRadians();

        var ct = Cos(headingAngle);
        var st = Sin(headingAngle);

        var t = new Matrix(new double[,] { { ct, st, 0 }, { -st, ct, 0 }, { 0, 0, 1 } });

        return t;
    }

    public Matrix CalculateTransformationMatrixPitch()
    {
        var pitchAngle = PitchAngleDeg.DegreesToRadians();

        var cp = Cos(pitchAngle);
        var sp = Sin(pitchAngle);

        var t = new Matrix(new double[,] { { cp, 0, -sp }, { 0, 1, 0 }, { sp, 0, cp } });

        return t;
    }

    public Matrix CalculateTransformationMatrixBank()
    {
        var bankAngle = BankAngleDeg.DegreesToRadians();

        var ct = Cos(bankAngle);
        var st = Sin(bankAngle);

        var t = new Matrix(new double[,] { { 1, 0, 0 }, { 0, ct, st }, { 0, -st, ct } });

        return t;
    }
}