using MissionEngineering.MathLibrary;

namespace MissionEngineering.Pulse;

public record PulseTransmit
{
    public int FlightpathId { get; set; }

    public int SensorId { get; set; }

    public int TransmitterId { get; set; }

    public int TransmitterPulseId { get; set; }

    public PositionLLA PositionLLA { get; set; }

    public PositionLLA PositionNED { get; set; }

    public PositionLLA VelocityNED { get; set; }

    public DateTime PulseStartDateTime { get; set; }

    public double PulseStartTime { get; set; }

    public double PulseEndTime { get; set; }

    public double PulseWidth => PulseEndTime - PulseStartTime;

    public int NumberOfSamples { get; set; }

    public double RfFrequencyStart { get; set; }

    public double RfFrequencyEnd { get; set; }

    public double RfFrequencyBandwidth => RfFrequencyEnd - RfFrequencyStart;

    public double PulsePower { get; set; }

    public double PulsePower_dB => PulsePower.PowerToDecibels();

    public double PhaseShift { get; set; }
}