using System.Text;
using MissionEngineering.Core;
using MissionEngineering.Scenario;
using MissionEngineering.ScenarioGenerator;

namespace MissionEngineering.SimdisLibrary.Tests
{
    [TestClass]
    public sealed class SimdisExporterTests
    {
        [TestMethod]
        public void GenerateSimdisData_WithSimulationData_ExpectSuccess()
        {
            // Arrange:
            var scenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();

            var scenarioGenerator = ScenarioBuilder.CreateScenarioGenerator();

            scenarioGenerator.ScenarioSettings = scenarioSettings;

            //
            scenarioGenerator.Run();

            scenarioGenerator.DataRecorder.SimdisExporter.GenerateSimdisData();

            var simdisString = scenarioGenerator.DataRecorder.SimdisExporter.SimdisData.ToString();

            //
            Assert.IsTrue(simdisString.Length > 100);
        }
    }
}
