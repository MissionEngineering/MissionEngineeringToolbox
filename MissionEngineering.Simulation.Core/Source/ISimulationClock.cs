namespace MissionEngineering.Simulation.Core
{
    public interface ISimulationClock
    {
        IDateTimeOrigin DateTimeOrigin { get; set; }

        TimeStamp GetTimeStamp(double time);
    }
}