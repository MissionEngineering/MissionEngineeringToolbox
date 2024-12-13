using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner;

public class Scanner : IScanner, IExecutableModel
{
    public ScanDynamics ScanDynamics { get; set; }

    public ScanPatternDemand ScanPatternDemand { get; set; }

    public ScanStateData ScanStateData { get; set; }

    public Scanner(ScanDynamics scanDynamics, ScanPatternDemand scanPatternDemand)
    {
        ScanDynamics = scanDynamics;
        ScanPatternDemand = scanPatternDemand;
    }

    public void Initialise(double time)
    {

    }

    public void Update(double time)
    {
    }

    public void Finalise(double time)
    {
    }
}