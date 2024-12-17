using System.Security.Cryptography;
using MissionEngineering.MathLibrary;

namespace MissionEngineering.Scenario;

public class FlightpathAutopilot
{
    public FlightpathDemand FlightpathDemand { get; set; }

    public FlightpathStateData FlightpathData { get; set; }

    public FlightpathDynamics FlightpathDynamics { get; set; }

    public FlightpathAutopilot(FlightpathDynamics flightpathDynamics)
    {
        FlightpathDynamics = flightpathDynamics;

        FlightpathDemand = new FlightpathDemand();
        FlightpathData = new FlightpathStateData();
    }

    public AccelerationTBA GetAccelerationTBA(double time)
    {
        var accelerationTBA = new AccelerationTBA();

        return accelerationTBA;
    }

    public bool SetFlightpathDemand(FlightpathDemand flightpathDemand)
    {
        FlightpathDemand = flightpathDemand;

        var isAcceptDemand = true;

        return isAcceptDemand;
    }
}



//        %%
//        function isAcceptDemand = SetFlightpathDemand(this, flightpathDemand)

//            d = this.flightpathDemand;

//    d.platformId = flightpathDemand.platformId;
//    d.time       = flightpathDemand.time;

//    [isAcceptHeadingDemand, headingAngleDemandDeg] = this.IsAcceptDemand(d.headingAngleDemandDeg, flightpathDemand.headingAngleDemandDeg, this.headingAngleToleranceDeg);
//    [isAcceptSpeedDemand, speedDemand]           = this.IsAcceptDemand(d.speedDemand          , flightpathDemand.speedDemand          , this.speedTolerance);
//    [isAcceptAltitudeDemand, altitudeDemand]        = this.IsAcceptDemand(d.altitudeDemand       , flightpathDemand.altitudeDemand       , this.altitudeTolerance);

//            if (isAcceptHeadingDemand)
//                d.headingAngleDemandDeg = headingAngleDemandDeg;
//    end

//            if (isAcceptSpeedDemand)
//                d.speedDemand = speedDemand;
//    end

//            if (isAcceptAltitudeDemand)
//                d.altitudeDemand = altitudeDemand;
//    end

//            isAcceptDemand = isAcceptHeadingDemand || isAcceptSpeedDemand || isAcceptAltitudeDemand;

//    end

//        %%
//        function [isAcceptDemand, demand] = IsAcceptDemand(this, old, new, tolerance)

//            isAcceptDemand = false;
//            demand         = new;

//            if (isnan(new))
//                return;
//            end

//            diff = abs(old - new);

//            if (diff > tolerance)
//                isAcceptDemand = true;
//                demand         = new;
//            end

//        end

//        %%
//        function[accelerationTBA, pitchAngleDemandDeg] = GetAccelerationTBA(this, time)

//            axialAcceleration    = this.GetAxialAcceleration(time);
//lateralAcceleration  = this.GetLateralAcceleration(time);

//[verticalAcceleration, pitchAngleDemandDeg] = this.GetVerticalAcceleration(time);

//accelerationTBA = [axialAcceleration, lateralAcceleration, verticalAcceleration]';

//        end

//        %%
//        function axialAcceleration = GetAxialAcceleration(this, time)

//            speed = norm(this.velocityNED);

//speedDemand = this.flightpathDemand.speedDemand;

//speedError = speed - speedDemand;

//axialAcceleration = -speedError * this.axialAccelerationGain;

//axialAcceleration = MathUtilities.LimitWithinRange(-this.axialAccelerationMax, this.axialAccelerationMax, axialAcceleration);

//end

//        %%
//        function lateralAcceleration = GetLateralAcceleration(this, time)

//            headingAngleDeg       = this.attitudeAnglesDeg(1);
//headingAngleDemandDeg = this.flightpathDemand.headingAngleDemandDeg;

//headingAngleErrorDeg = MathUtilities.AzimuthDifferenceDeg(headingAngleDeg, headingAngleDemandDeg);

//lateralAcceleration = -headingAngleErrorDeg * this.lateralAccelerationGain;

//lateralAcceleration = MathUtilities.LimitWithinRange(-this.lateralAccelerationMax, this.lateralAccelerationMax, lateralAcceleration);

//end

//        %%
//        function [verticalAcceleration, pitchAngleDemandDeg] = GetVerticalAcceleration(this, time)

//            altitude       = -this.positionNED(3);
//altitudeDemand = this.flightpathDemand.altitudeDemand;

//altitudeError = altitude - altitudeDemand;

//pitchAngleDemandDeg = -altitudeError * this.pitchAngleGain;

//pitchAngleDemandDeg = MathUtilities.LimitWithinRange(-this.pitchAngleMax, this.pitchAngleMax, pitchAngleDemandDeg);

//pitchAngleDeg    = this.attitudeAnglesDeg(2);

//pitchAngleErorDeg = pitchAngleDeg - pitchAngleDemandDeg;

//verticalAcceleration = pitchAngleErorDeg * this.verticalAccelerationGain;

//verticalAcceleration = MathUtilities.LimitWithinRange(-this.verticalAccelerationMax, this.verticalAccelerationMax, verticalAcceleration);

//end

//    end

//end