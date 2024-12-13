using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner.Source;

public class ScanPatternDemandUpdateCommand : IModelCommand
{
    public ScanPatternDemand ScanPatternDemand { get; set; }
}