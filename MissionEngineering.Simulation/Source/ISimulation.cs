using MissionEngineering.DataRecorder;
using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

public interface ISimulation
{
    IDataRecorder DataRecorder { get; set; }

    ILLAOrigin LLAOrigin { get; set; }

    IScenario Scenario { get; set; }

    SimulationSettings SimulationSettings { get; set; }

    ScenarioSettings ScenarioSettings { get; set; }

    ISimulationClock SimulationClock { get; set; }

    void CreateZipFile();

    void Finalise(double time);

    List<FlightpathStateData> GenerateFlightpathDataAll();

    void Initialise(double time);

    void Run();

    void Update(double time);
}