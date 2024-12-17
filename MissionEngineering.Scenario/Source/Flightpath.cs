﻿using MissionEngineering.MathLibrary;
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

        FlightpathStateData = new FlightpathStateData()
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
        var dt = time - FlightpathStateData.TimeStamp.Time;

        var deltaTime = new DeltaTime(dt);

        var attitude = FrameConversions.GetAttitudeFromVelocityVector(FlightpathStateData.VelocityNED);

        var accelerationTBA = FlightpathAutopilot.GetAccelerationTBA(time);
        var accelerationNED = FrameConversions.GetAccelerationNED(accelerationTBA, attitude);

        var velocityNED = FlightpathStateData.VelocityNED + FlightpathStateData.AccelerationNED * deltaTime;
        var positionNED = FlightpathStateData.PositionNED + FlightpathStateData.VelocityNED * deltaTime;
        var positionLLA = positionNED.ToPositionLLA(LLAOrigin.PositionLLA);

        var attitudeRate = new AttitudeRate();

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
        };

        FlightpathStateDataList.Add(FlightpathStateData);
    }

    public void Finalise(double time)
    {
    }
}