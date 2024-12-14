using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner
{
    public interface IScanGenerator
    {
        IScanner Scanner { get; set; }

        ISimulationClock SimulationClock { get; set; }

        SimulationClockSettings SimulationClockSettings { get; set; }

        void Run();

        void Initialise(double time);

        void Update(double time);

        void Finalise(double time);
    }
}