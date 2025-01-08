using MissionEngineering.MathLibrary;

namespace MissionEngineering.Scenario;

public class FlightpathAutopilot
{
    public FlightpathDemand FlightpathDemand { get; set; }

    public FlightpathStateData FlightpathStateData { get; set; }

    public FlightpathDynamics FlightpathDynamics { get; set; }

    public FlightpathAutopilot(FlightpathDynamics flightpathDynamics)
    {
        FlightpathDynamics = flightpathDynamics;

        FlightpathDemand = new FlightpathDemand();
        FlightpathStateData = new FlightpathStateData();
    }

    public void Initialise(double time)
    {
        FlightpathDemand.FlightpathDemandFlightpathId = FlightpathStateData.FlightpathId;
        FlightpathDemand.FlightpathDemandTime = time;
        FlightpathDemand.HeadingAngleDemandDeg = FlightpathStateData.Attitude.HeadingAngleDeg;
        FlightpathDemand.TotalSpeedDemand = FlightpathStateData.VelocityNED.TotalSpeed;
        FlightpathDemand.AltitudeDemand = FlightpathStateData.PositionLLA.Altitude;
    }

    public AccelerationTBA GetAccelerationTBA(double time)
    {
        var axialAcceleration = GetAxialAcceleration();
        var lateralAcceleration = GetLateralAcceleration();
        var verticalAcceleration = GetVerticalAcceleration();

        var accelerationTBA = new AccelerationTBA(axialAcceleration, lateralAcceleration, verticalAcceleration);

        return accelerationTBA;
    }

    public void SetFlightpathDemand(FlightpathDemand flightpathDemand)
    {
        var flightpathDemandId = FlightpathDemand.FlightpathDemandModificationId;

        flightpathDemandId++;

        FlightpathDemand = flightpathDemand with { FlightpathDemandModificationId = flightpathDemandId };
    }

    public double GetAxialAcceleration()
    {
        var axialAccelerationMax = FlightpathDynamics.AxialAccelerationMaximum;

        var speed = FlightpathStateData.VelocityNED.TotalSpeed;

        var speedDemand = FlightpathDemand.TotalSpeedDemand;

        var speedError = speed - speedDemand;

        var axialAcceleration = -speedError * FlightpathDynamics.AxialAccelerationGain;

        axialAcceleration = MathFunctions.LimitWithinRange(-axialAccelerationMax, axialAccelerationMax, axialAcceleration);

        return axialAcceleration;
    }

    public double GetLateralAcceleration()
    {
        var lateralAccelerationMax = FlightpathDynamics.LateralAccelerationMaximum;

        var headingAngleDeg = FlightpathStateData.Attitude.HeadingAngleDeg;

        var headingAngleDemandDeg = FlightpathDemand.HeadingAngleDemandDeg;

        var headingAngleErrorDeg = MathFunctions.AzimuthDifferenceDeg(headingAngleDeg, headingAngleDemandDeg);

        var lateralAcceleration = -headingAngleErrorDeg * FlightpathDynamics.LateralAccelerationGain;

        lateralAcceleration = MathFunctions.LimitWithinRange(-lateralAccelerationMax, lateralAccelerationMax, lateralAcceleration);

        var bankAngleDemandMaxDeg = FlightpathDynamics.BankAngleMaximumDeg;

        var bankAngleDemandDeg = SetBankAngleFromLateralAcceleration(lateralAcceleration);

        bankAngleDemandDeg = MathFunctions.LimitWithinRange(-bankAngleDemandMaxDeg, bankAngleDemandMaxDeg, bankAngleDemandDeg);

        var bankAngleDeg = FlightpathStateData.Attitude.BankAngleDeg;

        var bankAngleErrorDeg = bankAngleDeg - bankAngleDemandDeg;

        var bankAngleRateDemandDeg = -bankAngleErrorDeg * FlightpathDynamics.BankAngleGain;

        FlightpathDemand = FlightpathDemand with { BankAngleDemandDeg = bankAngleDemandDeg, BankAngleRateDemandDeg = bankAngleRateDemandDeg };

        return lateralAcceleration;
    }

    public double GetVerticalAcceleration()
    {
        var pitchAngleMaxDeg = FlightpathDynamics.PitchAngleMaximumDeg;
        var verticalAccelerationMax = FlightpathDynamics.VerticalAccelerationMaximum;

        var altitude = FlightpathStateData.PositionLLA.Altitude;

        var altitudeDemand = FlightpathDemand.AltitudeDemand;

        var altitudeError = altitude - altitudeDemand;

        var pitchAngleDemandDeg = -altitudeError * FlightpathDynamics.PitchAngleGain;

        pitchAngleDemandDeg = MathFunctions.LimitWithinRange(-pitchAngleMaxDeg, pitchAngleMaxDeg, pitchAngleDemandDeg);

        var pitchAngleDeg = FlightpathStateData.Attitude.PitchAngleDeg;

        var pitchAngleErorDeg = pitchAngleDeg - pitchAngleDemandDeg;

        var verticalAcceleration = pitchAngleErorDeg * FlightpathDynamics.VerticalAccelerationGain;

        verticalAcceleration = MathFunctions.LimitWithinRange(-verticalAccelerationMax, verticalAccelerationMax, verticalAcceleration);

        FlightpathDemand = FlightpathDemand with { PitchAngleDemandDeg = pitchAngleDemandDeg };

        return verticalAcceleration;
    }

    public double SetBankAngleFromLateralAcceleration(double lateralAcceleration)
    {
        if (!FlightpathDynamics.IsUseBankedTurns)
        {
            return 0.0;
        }

        var bankAngleDemandDeg = MathFunctions.CalculateBankAngleDegFromLateralAcceleration(lateralAcceleration);

        return bankAngleDemandDeg;
    }
}