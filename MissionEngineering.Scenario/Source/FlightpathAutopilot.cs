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
        FlightpathDemand.FlightpathId = FlightpathStateData.FlightpathId;
        FlightpathDemand.Time = time;
        FlightpathDemand.HeadingAngleDemandDeg = FlightpathStateData.Attitude.HeadingAngleDeg;
        FlightpathDemand.SpeedDemand = FlightpathStateData.VelocityNED.TotalSpeed;
        FlightpathDemand.AltitudeDemand = FlightpathStateData.PositionLLA.Altitude;
    }

    public AccelerationTBA GetAccelerationTBA(double time)
    {
        var axialAcceleration = GetAxialAcceleration();
        var lateralAcceleration = GetLateralAcceleration();
        var (verticalAcceleration, pitchAngleDemandDeg) = GetVerticalAcceleration();

        var accelerationTBA = new AccelerationTBA(axialAcceleration, lateralAcceleration, verticalAcceleration);

        return accelerationTBA;
    }

    public void SetFlightpathDemand(FlightpathDemand flightpathDemand)
    {
        FlightpathDemand = flightpathDemand;
    }

    public double GetAxialAcceleration()
    {
        var axialAccelerationMax = FlightpathDynamics.AxialAccelerationMaximum;

        var speed = FlightpathStateData.VelocityNED.TotalSpeed;

        var speedDemand = FlightpathDemand.SpeedDemand;

        var speedError = speed - speedDemand;

        var axialAcceleration = -speedError * FlightpathDynamics.AxialAccelerationGain;

        axialAcceleration = MathFunctions.LimitWithinRange(-axialAccelerationMax, axialAccelerationMax, axialAcceleration);

        return axialAcceleration;
    }

    public double GetLateralAcceleration()
    {
        var lateralAccelerationMax = FlightpathDynamics.LateralAccelerationMaximum;

        var headingAngleDeg       = FlightpathStateData.Attitude.HeadingAngleDeg;
        
        var headingAngleDemandDeg = FlightpathDemand.HeadingAngleDemandDeg;

        var headingAngleErrorDeg = MathFunctions.AzimuthDifferenceDeg(headingAngleDeg, headingAngleDemandDeg);

        var lateralAcceleration = -headingAngleErrorDeg * FlightpathDynamics.LateralAccelerationGain;

        lateralAcceleration = MathFunctions.LimitWithinRange(-lateralAccelerationMax, lateralAccelerationMax, lateralAcceleration);

        return lateralAcceleration;
    }

    public (double verticalAcceleration, double pitchAngleDemandDeg) GetVerticalAcceleration()
    {
        var pitchAngleMaxDeg = FlightpathDynamics.PitchAngleMaximumDeg;
        var verticalAccelerationMax = FlightpathDynamics.VerticalAccelerationMaximum;

        var altitude       = FlightpathStateData.PositionLLA.Altitude;

        var altitudeDemand = FlightpathDemand.AltitudeDemand;

        var altitudeError = altitude - altitudeDemand;

        var pitchAngleDemandDeg = -altitudeError * FlightpathDynamics.PitchAngleGain;

        pitchAngleDemandDeg = MathFunctions.LimitWithinRange(-pitchAngleMaxDeg, pitchAngleMaxDeg, pitchAngleDemandDeg);

        var pitchAngleDeg    = FlightpathStateData.Attitude.PitchAngleDeg;

        var pitchAngleErorDeg = pitchAngleDeg - pitchAngleDemandDeg;

        var verticalAcceleration = pitchAngleErorDeg * FlightpathDynamics.VerticalAccelerationGain;

        verticalAcceleration = MathFunctions.LimitWithinRange(-verticalAccelerationMax, verticalAccelerationMax, verticalAcceleration);

        return (verticalAcceleration, pitchAngleDemandDeg);
    }
}