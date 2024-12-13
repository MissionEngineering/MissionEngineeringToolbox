using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner.Source;

public class ScanStateInitialisedEvent : IModelEvent
{
    public ScanStateData ScanStateData { get; set; }
}