namespace MissionEngineering.Pulse.Tests;

[TestClass]
public sealed class WaverformTests
{
    [TestMethod]
    public void Create_WithValidData_ExpectSuccess()
    {
        // Arrange:
        var waveform = new Waveform()
        {
            WaveformId = 1,
            WaveformName = "Waveform_1",
            RfFrequency = 9.0e9,
            PulseWidth = 1.0e-6,
            PulseBandwidth = 5.0e6,
            PulseRepetitionFrequency = 150000,
            NumberOfPulses = 2000
        };

        // Act:

        // Assert:
        Assert.AreEqual(9000.0, waveform.RfFrequency_MHz);
        Assert.AreEqual(33.33333333333333, waveform.RfWavelength_mm, 1.0e-8);
        Assert.AreEqual(5.0, waveform.PulseCompressionRatio, 1.0e-8);
        Assert.AreEqual(30.0, waveform.RangeGateWidth);
        Assert.AreEqual(75.0, waveform.DopplerGateWidth);
        Assert.AreEqual(1.25, waveform.RangeRateGateWidth);
        Assert.AreEqual(0.01333333333333333, waveform.DwellTime, 1.0e-8);
    }
}