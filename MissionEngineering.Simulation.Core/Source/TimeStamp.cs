namespace MissionEngineering.Simulation;

public record TimeStamp
{
    public DateTime DateTime { get; init; }

    public double Time { get; init; }

    public TimeStamp() : this(default, default)
    {
    }

    public TimeStamp(double time, DateTime dateTime)
    {
        Time = time;
        DateTime = dateTime;
    }
}