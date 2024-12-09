namespace MissionEngineering.Simulation;

public record TimeStamp
{
    public double SimulationTime { get; init; }

    public DateTime SimulationDateTime { get; init; }
}