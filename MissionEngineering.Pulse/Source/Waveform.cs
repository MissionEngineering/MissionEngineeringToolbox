using MissionEngineering.Core;
using MissionEngineering.MathLibrary;

using static MissionEngineering.MathLibrary.RadarFunctions;

namespace MissionEngineering.Pulse;

public class Waveform
{
    public int WaveformId { get; set; }

    public string WaveformName { get; set; }

    public double RfFrequency { get; set; }

    public double RfFrequency_MHz => RfFrequency / 1.0e6;

    public double RfWavelength => FrequencyToWavelength(RfFrequency);

    public double RfWavelength_mm => RfWavelength * 1.0e3;

    public double PulseWidth { get; set; }

    public double PulseWidth_us => PulseWidth * 1.0e6;

    public double PulseBandwidth { get; set; }

    public double PulseBandwidth_MHz => PulseBandwidth / 1.0e6;

    public double PulseCompressionRatio => CalculatePulseCompressionRatio(PulseWidth, PulseBandwidth);

    public double PulseRepetitionFrequency { get; set; }

    public double PulseRepetitionInterval => 1.0 / PulseRepetitionFrequency;

    public double NumberOfPulses { get; set; }

    public double MaximumUnambiguousRange => CalculateMaximumUnambiguousRange(PulseRepetitionFrequency);

    public double MaximumUnambiguousDopplerTotal => PulseRepetitionFrequency;

    public double MaximumUnambiguousDopplerPlusMinus => MaximumUnambiguousDopplerTotal / 2.0;

    public double MaximumUnambiguousRangeRateTotal => CalculateMaximumUnambiguousRangeRate(RfFrequency, PulseRepetitionFrequency);

    public double MaximumUnambiguousRangeRatePlusMinus => MaximumUnambiguousRangeRateTotal / 2.0;

    public double RangeGateWidthUncompressed => CalculateRangeFromDelayTimeTwoWay(PulseWidth);

    public double RangeGateWidth => RangeGateWidthUncompressed / PulseCompressionRatio;

    public double DopplerGateWidth => MaximumUnambiguousDopplerTotal / NumberOfPulses;

    public double RangeRateGateWidth => MaximumUnambiguousRangeRateTotal / NumberOfPulses;

    public double DwellTime => PulseRepetitionInterval * NumberOfPulses;
}
