using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator
{
    public interface IScenarioGenerator
    {
        ILLAOrigin LLAOrigin { get; set; }

        IScenario Scenario { get; set; }

        ScenarioSettings ScenarioSettings { get; set; }

        ISimulationClock SimulationClock { get; set; }

        void Run();

        void Initialise(double time);

        void Update(double time);

        void Finalise(double time);

        void WriteToCsv(string path);
    }
}