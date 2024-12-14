using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner.Source;

public class InitialiseScanStateCommand : IModelCommand
{
    public ScanStateData ScanStateData { get; set; }
}