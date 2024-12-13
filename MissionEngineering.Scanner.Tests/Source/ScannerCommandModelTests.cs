using System.ComponentModel.DataAnnotations;
using MissionEngineering.Scanner.Source;

namespace MissionEngineering.Scanner.Tests
{
    [TestClass]
    public sealed class ScannerCommandModelTests
    {
        [TestMethod]
        public void ProcessScanStateInitialiseCommand_ExpectSuccess()
        {
            // Arrange:
            var scanDynamics = new ScanDynamics();
            var scanPatternDemand = new ScanPatternDemand();

            var scanner = new Scanner(scanDynamics, scanPatternDemand);

            var scannerCommandModel = new ScannerCommandModel(scanner);

            var scanStateData = new ScanStateData();

            var command = new ScanStateInitialiseCommand()
            { 
                ScanStateData = scanStateData 
            };

            // Act:
            scannerCommandModel.ProcessCommand(command);

            // Assert:
            Assert.Inconclusive();
        }
    }
}
