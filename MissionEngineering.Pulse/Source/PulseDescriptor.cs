using MissionEngineering.MathLibrary;

namespace MissionEngineering.Pulse;

public record PulseDescriptor
{
    public int TransmitterId { get; set; }

    public int TransmitterPulseId { get; set; }

    public int ReceiverId { get; set; }

    public int ReceiverPulseId { get; set; }

    public DateTime PulseStartDateTime { get; set; }

    public double PulseStartTime { get; set; }

    public double PulseEndTime { get; set; }

    public double PulseWidth => PulseEndTime - PulseStartTime;

    public double SampleRate { get; set; }

    public int NumberOfSamples { get; set; }

    public double RfFrequencyStart { get; set; }

    public double RfFrequencyEnd { get; set; }

    public double RfFrequencyBandwidth => RfFrequencyEnd - RfFrequencyStart;

    public double PulsePower { get; set; }

    public double PulsePower_dB => PulsePower.PowerToDecibels();

    public double PhaseShift { get; set; }
}