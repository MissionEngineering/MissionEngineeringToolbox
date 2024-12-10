using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public class Flightpath
{
    public FlightpathSettings FlightpathSettings { get; set; }

    public FlightpathData FlightpathData { get; set; }

    public List<FlightpathData> FlightpathDataList { get; set; }

    public IFlightpathAccelerationGenerator FlightpathAccelerationGenerator { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public Flightpath(IFlightpathAccelerationGenerator flightpathAccelerationGenerator, ISimulationClock simulationClock, ILLAOrigin llaOrigin)
    {
        FlightpathAccelerationGenerator = flightpathAccelerationGenerator;
        SimulationClock = simulationClock;
        LLAOrigin = llaOrigin;

        FlightpathSettings = new FlightpathSettings();
        FlightpathData = new FlightpathData();
        FlightpathDataList = new List<FlightpathData>();
    }

    public void Run()
    {
        var time = FlightpathSettings.TimeStart;

        Initialise(time);

        while (time <= FlightpathSettings.TimeEnd)
        {
            Update(time);

            time += FlightpathSettings.TimeStep;
        }

        Finalise(time);
    }

    public void Initialise(double time)
    {
        var timeStamp = SimulationClock.GetTimeStamp(time);

        FlightpathData = new FlightpathData()
        {
            FlightpathId = FlightpathSettings.FlightpathId,
            FlightpathName = FlightpathSettings.FlightpathName,
            TimeStamp = timeStamp,
            PositionNED = FlightpathSettings.PositionNED,
            VelocityNED = FlightpathSettings.VelocityNED
        };
    }

    public void Update(double time)
    {
        var dt = time - FlightpathData.TimeStamp.Time;

        var deltaTime = new DeltaTime(dt);

        var accelerationTBA = FlightpathAccelerationGenerator.GetAccelerationTBA(time);
        var accelerationNED = new AccelerationNED();

        var velocityNED = FlightpathData.VelocityNED + FlightpathData.AccelerationNED * deltaTime;
        var positionNED = FlightpathData.PositionNED + FlightpathData.VelocityNED * deltaTime;
        var positionLLA = positionNED.ToPositionLLA(LLAOrigin.PositionLLA);

        var attitude = new Attitude();
        var attitudeRate = new AttitudeRate();

        var timeStamp = SimulationClock.GetTimeStamp(time);

        FlightpathData = new FlightpathData()
        {
            FlightpathId = FlightpathSettings.FlightpathId,
            FlightpathName = FlightpathSettings.FlightpathName,
            TimeStamp = timeStamp,
            PositionLLA = positionLLA,
            PositionNED = positionNED,
            VelocityNED = velocityNED,
            AccelerationNED = accelerationNED,
            AccelerationTBA = accelerationTBA,
            Attitude = attitude,
            AttitudeRate = attitudeRate,
        };

        FlightpathDataList.Add(FlightpathData);
    }

    public void Finalise(double time)
    {
    }
}