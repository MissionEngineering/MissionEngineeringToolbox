using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner
{
    public interface IScanner
    {
        ScanDynamics ScanDynamics { get; set; }

        ScanPatternDemand ScanPatternDemand { get; set; }

        ScanStateData ScanStateData { get; set; }
    }
}