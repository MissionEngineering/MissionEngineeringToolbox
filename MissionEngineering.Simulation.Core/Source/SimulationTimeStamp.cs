namespace MissionEngineering.Simulation;

public record SimulationTimeStamp
{
    public DateTime DateTime { get; init; }

    public double Time { get; init; }

    public SimulationTimeStamp() : this(default, default)
    {
    }

    public SimulationTimeStamp(double time, DateTime dateTime)
    {
        Time = time;
        DateTime = dateTime;
    }
}