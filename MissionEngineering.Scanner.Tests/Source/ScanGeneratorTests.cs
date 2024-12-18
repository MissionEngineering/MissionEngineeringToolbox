namespace MissionEngineering.Scanner.Tests
{
    [TestClass]
    public sealed class ScanGeneratorTests
    {
        [TestMethod]
        public void Run_WithValidData_ExpectSuccess()
        {
            // Arrange:
            var scanGenerator = ScanBuilder.CreateScanGenerator();

            scanGenerator.SimulationClockSettings.DateTimeOrigin = new DateTime(2024, 01, 30);
            scanGenerator.SimulationClockSettings.TimeStart = 5.0;
            scanGenerator.SimulationClockSettings.TimeEnd = 100.0;
            scanGenerator.SimulationClockSettings.TimeStep = 0.1;

            // Act:
            scanGenerator.Run();

            // Assert:
            Assert.Inconclusive();
        }
    }
}