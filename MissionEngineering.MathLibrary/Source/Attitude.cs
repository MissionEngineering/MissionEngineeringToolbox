namespace MissionEngineering.MathLibrary;

public record Attitude
{
    public double HeadingAngleDeg { get; init; }

    public double PitchAngleDeg { get; init; }

    public double BankAngleDeg { get; init; }

    public Attitude(double headingAngleDeg, double pitchAngleDeg, double bankAngleDeg)
    {
        HeadingAngleDeg = headingAngleDeg;
        PitchAngleDeg = pitchAngleDeg;
        BankAngleDeg = bankAngleDeg;
    }
}
