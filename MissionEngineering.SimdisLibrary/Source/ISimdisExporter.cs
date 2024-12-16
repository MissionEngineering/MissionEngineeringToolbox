using System.Text;
using MissionEngineering.DataRecorder;

namespace MissionEngineering.SimdisLibrary;

public interface ISimdisExporter
{
    public IDataRecorder DataRecorder { get; set; }

    StringBuilder SimdisData { get; set; }

    void GenerateSimdisData();

    void WriteSimdisData();
}