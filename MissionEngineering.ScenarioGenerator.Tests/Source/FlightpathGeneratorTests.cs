using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator.Tests;

[TestClass]
public sealed class FlightpathGeneratorTests
{
    [TestMethod]
    public void Run_WithValidData_ExpectSuccess()
    {
        // Arrange:
        var flightpathSettings = FlightpathSettingsFactory.FlightpathSettings_Test_1();

        var dateTimeOrigin = new DateTime(2024, 12, 24, 15, 45, 10, 123);

        var simulationClockSettings = new SimulationClockSettings()
        {
            DateTimeOrigin = dateTimeOrigin,
            TimeStart = 10.0,
            TimeEnd = 100.0,
            TimeStep = 0.1
        };

        var llaOrigin = new LLAOrigin()
        {
            PositionLLA = new PositionLLA()
            {
                LatitudeDeg = 55.1,
                LongitudeDeg = 12.0,
                Altitude = 0.0
            }
        };

        var flightpathGenerator = new FlightpathGenerator(simulationClockSettings, llaOrigin)
        {
            FlightpathSettings = flightpathSettings
        };

        var expectedListLength = 901;

        // Act:
        flightpathGenerator.Run();

        // Assert:
        Assert.AreEqual(expectedListLength, flightpathGenerator.Flightpath.FlightpathStateDataList.Count);
    }
}