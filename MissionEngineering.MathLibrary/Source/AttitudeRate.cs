namespace MissionEngineering.MathLibrary;

public record AttitudeRate
{
    public double HeadingRateDeg { get; init; }

    public double PitchRateDeg { get; init; }

    public double BankRateDeg { get; init; }

    public AttitudeRate()
    {
    }

    public AttitudeRate(double headingRateDeg, double pitchRateDeg, double bankRateDeg)
    {
        HeadingRateDeg = headingRateDeg;
        PitchRateDeg = pitchRateDeg;
        BankRateDeg = bankRateDeg;
    }
}