using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

public interface ISimulationHarness
{
    SimulationHarnessSettings SimulationHarnessSettings { get; set; }

    SimulationSettings SimulationSettings { get; set; }

    ScenarioSettings ScenarioSettings { get; set; }

    IFlightpathDemandList FlightpathDemandList { get; set; }

    ISimulation Simulation { get; set; }

    void Run();
}