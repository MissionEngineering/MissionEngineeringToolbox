using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner
{
    public interface IScanner : IExecutableModel
    {
        ScanDynamics ScanDynamics { get; set; }

        ScanPatternDemand ScanPatternDemand { get; set; }

        ScanStateData ScanStateData { get; set; }

        List<ScanStateData> ScanStateDataList { get; set; }
    }
}