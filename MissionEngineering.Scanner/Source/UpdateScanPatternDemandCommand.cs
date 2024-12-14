using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner.Source;

public class UpdateScanPatternDemandCommand : IModelCommand
{
    public ScanPatternDemand ScanPatternDemand { get; set; }
}