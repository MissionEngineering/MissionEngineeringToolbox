using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner.Source;

public class ScanPatternDemandUpdatedEvent : IModelEvent
{
    public ScanPatternDemand ScanPatternDemand { get; set; }
}