namespace MissionEngineering.Simulation;

public record TimeStamp
{
    public DateTime DateTimeUTC { get; init; }

    public double Time { get; init; }

    public TimeStamp() : this(default, default)
    {
    }

    public TimeStamp(double time, DateTime dateTimeUTC)
    {
        Time = time;
        DateTimeUTC = dateTimeUTC;
    }
}