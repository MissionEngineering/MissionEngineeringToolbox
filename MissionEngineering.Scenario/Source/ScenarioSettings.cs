using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scenario;

public record ScenarioSettings
{
    public string ScenarioName { get; set; }

    public SimulationClockSettings SimulationClockSettings { get; set; }

    public PositionLLA LLAOrigin { get; set; }

    public List<FlightpathSettings> FlightpathSettingsList { get; set; }
}