using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MissionEngineering.MathLibrary.PhysicalConstants;

namespace MissionEngineering.MathLibrary;

public static class RadarFunctions
{
    public static double FrequencyToWavelength(double frequency)
    {
        var wavelength = SpeedOfLight / frequency;

        return wavelength;
    }

    public static double WavelengthToFrequency(double wavelength)
    {
        var frequency = SpeedOfLight / wavelength;

        return frequency;
    }

    public static double CalculateMaximumUnambiguousRange(double pulseRepetitionFrequency)
    {
        var maximumUnambiguousRange = SpeedOfLight / (2.0 * pulseRepetitionFrequency);

        return maximumUnambiguousRange;
    }

    public static double CalculatePulseCompressionRatio(double pulseWidth, double pulseBandwidth)
    {
        var pulseCompressionRatio = pulseWidth * pulseBandwidth;

        return pulseCompressionRatio;
    }

    public static double CalculateMaximumUnambiguousRangeRate(double rfFrequency, double pulseRepetitionFrequency)
    {
        var rfWavelength = FrequencyToWavelength(rfFrequency);

        var maximumUnambiguousRangeRate = rfWavelength * pulseRepetitionFrequency / 2.0;

        return maximumUnambiguousRangeRate;
    }

    public static double CalculateRangeGateWidth(double pulseWidth)
    {
        var rangeGateWidth = CalculateRangeFromDelayTimeTwoWay(pulseWidth);

        return rangeGateWidth;
    }

    public static double CalculateRangeFromDelayTimeTwoWay(double delayTime)
    {
        var range = SpeedOfLight * delayTime / 2.0; 

        return range;
    }
}
