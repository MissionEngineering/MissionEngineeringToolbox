using System.Text;
using MissionEngineering.Simulation;

namespace MissionEngineering.SimdisLibrary;

public interface ISimdisExporter
{
    public SimulationData SimulationData { get; set; }

    StringBuilder SimdisData { get; set; }

    void GenerateSimdisData();

    void WriteSimdisData();
}