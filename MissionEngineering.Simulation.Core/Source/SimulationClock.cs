namespace MissionEngineering.Simulation.Core;

public class SimulationClock : ISimulationClock
{
    public IDateTimeOrigin DateTimeOrigin { get; set; }

    public SimulationClock(IDateTimeOrigin dateTimeOrigin)
    {
        DateTimeOrigin = dateTimeOrigin;
    }

    public TimeStamp GetTimeStamp(double time)
    {
        var dateTime = DateTimeOrigin.DateTime.AddSeconds(time);

        var timeStamp = new TimeStamp(time, dateTime);

        return timeStamp;
    }
}