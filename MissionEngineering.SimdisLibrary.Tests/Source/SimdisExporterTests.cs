using MissionEngineering.ScenarioGenerator;
using MissionEngineering.Simulation;

namespace MissionEngineering.SimdisLibrary.Tests
{
    [TestClass]
    public sealed class SimdisExporterTests
    {
        [TestMethod]
        public void GenerateSimdisData_WithSimulationData_ExpectSuccess()
        {
            // Arrange:
            var simulationSettings = SimulationSettingsFactory.SimulationSettings_Test_1();
            var scenarioSettings = ScenarioSettingsFactory.ScenarioSettings_Test_1();

            var simulation = SimulationBuilder.CreateSimulation();

            simulation.SimulationSettings = simulationSettings;
            simulation.ScenarioSettings = scenarioSettings;

            //
            simulation.Run();

            simulation.DataRecorder.SimdisExporter.GenerateSimdisData();

            var simdisString = simulation.DataRecorder.SimdisExporter.SimdisData.ToString();

            //
            Assert.IsTrue(simdisString.Length > 100);
        }
    }
}