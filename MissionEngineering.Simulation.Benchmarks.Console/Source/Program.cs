using BenchmarkDotNet.Running;

namespace MissionEngineering.Simulation.Benchmarks.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SimulationBenchmarks>();
        }
    }
}
