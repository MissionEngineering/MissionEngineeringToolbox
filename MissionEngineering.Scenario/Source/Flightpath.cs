using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scenario;

public class Flightpath
{
    public FlightpathSettings FlightpathSettings { get; set; }

    public FlightpathStateData FlightpathStateData { get; set; }

    public List<FlightpathStateData> FlightpathStateDataList { get; set; }

    public FlightpathAutopilot FlightpathAutopilot { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public Flightpath(ISimulationClock simulationClock, ILLAOrigin llaOrigin, FlightpathAutopilot flightpathAutopilot)
    {
        SimulationClock = simulationClock;
        LLAOrigin = llaOrigin;
        FlightpathAutopilot = flightpathAutopilot;

        FlightpathStateData = new FlightpathStateData();
        FlightpathStateDataList = new List<FlightpathStateData>();
    }

    public void Initialise(double time)
    {
        var timeStamp = SimulationClock.GetTimeStamp(time);

        var attitude = FrameConversions.GetAttitudeFromVelocityVector(FlightpathSettings.VelocityNED);

        var positionLLA = FlightpathSettings.PositionNED.ToPositionLLA(LLAOrigin.PositionLLA);

        FlightpathStateData = new FlightpathStateData()
        {
            FlightpathId = FlightpathSettings.FlightpathId,
            FlightpathName = FlightpathSettings.FlightpathName,
            TimeStamp = timeStamp,
            PositionLLA = positionLLA,
            PositionNED = FlightpathSettings.PositionNED,
            VelocityNED = FlightpathSettings.VelocityNED,
            Attitude = attitude
        };

        FlightpathAutopilot.FlightpathStateData = FlightpathStateData;

        FlightpathAutopilot.Initialise(time);

        FlightpathStateData.FlightpathDemand = FlightpathAutopilot.FlightpathDemand;
    }

    public void Update(double time)
    {
        var dt = time - FlightpathStateData.TimeStamp.Time;

        var deltaTime = new DeltaTime(dt);

        var bankAngleDegOld = FlightpathStateData.Attitude.BankAngleDeg;

        var attitude = FrameConversions.GetAttitudeFromVelocityVector(FlightpathStateData.VelocityNED);

        FlightpathAutopilot.FlightpathStateData = FlightpathStateData;

        var accelerationTBA = FlightpathAutopilot.GetAccelerationTBA(time);
        var accelerationNED = FrameConversions.GetAccelerationNED(accelerationTBA, attitude);

        var velocityNED = FlightpathStateData.VelocityNED + FlightpathStateData.AccelerationNED * deltaTime;
        var positionNED = FlightpathStateData.PositionNED + FlightpathStateData.VelocityNED * deltaTime;
        var positionLLA = positionNED.ToPositionLLA(LLAOrigin.PositionLLA);

        var bankAngleRateDeg = FlightpathAutopilot.FlightpathDemand.BankAngleRateDemandDeg;

        var bankAngleDeg = bankAngleDegOld + bankAngleRateDeg * dt;

        attitude = attitude with { BankAngleDeg = bankAngleDeg };

        var attitudeRate = new AttitudeRate(0.0, 0.0, bankAngleRateDeg);

        var timeStamp = SimulationClock.GetTimeStamp(time);

        FlightpathStateData = new FlightpathStateData()
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
            FlightpathDemand = FlightpathAutopilot.FlightpathDemand
        };

        FlightpathStateDataList.Add(FlightpathStateData);
    }

    public void Finalise(double time)
    {
    }

    public void SetFlightpathDemand(FlightpathDemand flightpathDemand)
    {
        if (flightpathDemand.FlightpathDemandModificationId == FlightpathAutopilot.FlightpathDemand.FlightpathDemandModificationId)
        {
            return;
        }

        FlightpathAutopilot.SetFlightpathDemand(flightpathDemand);
    }
}