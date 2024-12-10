using MissionEngineering.Core.Source;
using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator.Tests;

[TestClass]
public sealed class FlightpathTests
{
    [TestMethod]
    public void Run_WithValidData_ExpectSuccess()
    {
        // Arrange:
        var flightpathSettings = new FlightpathSettings()
        {
            FlightpathId = 1,
            FlightpathName = "Flightpath_1",
            TimeStart = 10.0,
            TimeEnd = 100.0,
            TimeStep = 0.1
        };

        var flightpathAccelerationGenerator = new FlightpathAutopilot();

        var dateTime = new DateTime(2024, 12, 24, 15, 45, 10, 123);

        var dateTimeOrigin = new DateTimeOrigin(dateTime);

        var simulationClock = new SimulationClock(dateTimeOrigin);

        var llaOrigin = new LLAOrigin()
        {
            PositionLLA = new PositionLLA()
            {
                LatitudeDeg = 55.1,
                LongitudeDeg = 12.0,
                Altitude = 0.0
            }
        };

        var flightpath = new Flightpath(flightpathAccelerationGenerator, simulationClock, llaOrigin)
        {
            FlightpathSettings = flightpathSettings
        };

        var expectedListLength = 901;

        //var fileName = @"C:\Temp\MissionEngineeringToolbox\FlightpathData_Test_1.csv";

        // Act:
        flightpath.Run();

        //flightpath.FlightpathDataList.WriteToCsvFile(fileName);

        // Assert:
        Assert.AreEqual(expectedListLength, flightpath.FlightpathDataList.Count);
    }
}