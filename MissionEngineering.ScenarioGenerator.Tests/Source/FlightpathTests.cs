using MissionEngineering.Core.Source;

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

        var flightpath = new Flightpath()
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