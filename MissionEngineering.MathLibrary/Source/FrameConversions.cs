using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace MissionEngineering.MathLibrary;

public static class FrameConversions
{
    public static AccelerationNED GetAccelerationNED(AccelerationTBA accelerationTBA, Attitude attitude)
    {
        var t = attitude.GetTransformationMatrix().Transpose();

        var accelerationTBAVector = accelerationTBA.ToVector();

        var accelerationNEDVector = t * accelerationTBAVector;

        var accelerationNED = new AccelerationNED(accelerationNEDVector);

        return accelerationNED;
    }

    public static Attitude GetAttitudeFromVelocityVector(VelocityNED velocityNED)
    {
        var headingAngle = Atan2(velocityNED.VelocityEast, velocityNED.VelocityNorth);
        var pitchAngle = -Asin(velocityNED.VelocityDown / velocityNED.TotalSpeed);
        var bankAngle = 0.0;

        var headingAngleDeg = headingAngle.RadiansToDegrees();
        var pitchAngleDeg = pitchAngle.RadiansToDegrees();
        var bankAngleDeg = bankAngle.RadiansToDegrees();

        var attitude = new Attitude(headingAngleDeg, pitchAngleDeg, bankAngleDeg);

        return attitude;
    }
}