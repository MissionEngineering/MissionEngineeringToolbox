using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner.Source;

public class ScanStateInitialiseCommand : IModelCommand
{
    public ScanStateData ScanStateData { get; set; }
}