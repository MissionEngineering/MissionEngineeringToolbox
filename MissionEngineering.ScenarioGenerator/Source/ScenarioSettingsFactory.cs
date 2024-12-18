using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public static class ScenarioSettingsFactory
{
    public static ScenarioSettings ScenarioSettings_Test_1()
    {
        var dateTimeOrigin = new DateTime(2024, 12, 24, 15, 45, 10, 123);

        var simulationClockSettings = new SimulationClockSettings()
        {
            DateTimeOrigin = dateTimeOrigin,
            TimeStart = 10.0,
            TimeEnd = 200.0,
            TimeStep = 0.1
        };

        var llaOrigin = new PositionLLA()
        {
            LatitudeDeg = 55.1,
            LongitudeDeg = 12.0,
            Altitude = 0.0
        };

        var fs1 = FlightpathSettingsFactory.FlightpathSettings_Test_1();
        var fs2 = FlightpathSettingsFactory.FlightpathSettings_Test_2();

        var scenarioSettings = new ScenarioSettings()
        {
            ScenarioName = "Scenario_Test_1",
            SimulationClockSettings = simulationClockSettings,
            LLAOrigin = llaOrigin,
            FlightpathSettingsList = new List<FlightpathSettings> { fs1, fs2 }
        };

        return scenarioSettings;
    }
}