using MissionEngineering.DataRecorder;
using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator
{
    public interface IScenarioGenerator
    {
        ILLAOrigin LLAOrigin { get; set; }

        IScenario Scenario { get; set; }

        ScenarioSettings ScenarioSettings { get; set; }

        ISimulationClock SimulationClock { get; set; }

        public IDataRecorder DataRecorder { get; set; }

        void Run();

        void Initialise(double time);

        void Update(double time);

        void Finalise(double time);
    }
}