using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner;

public class Scanner : IScanner
{
    public ScanDynamics ScanDynamics { get; set; }

    public ScanPatternDemand ScanPatternDemand { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public ScanStateData ScanStateData { get; set; }

    public List<ScanStateData> ScanStateDataList { get; set; }

    public Scanner(ScanDynamics scanDynamics, ScanPatternDemand scanPatternDemand, ISimulationClock simulationClock, ScanStateData scanStateData)
    {
        ScanDynamics = scanDynamics;
        ScanPatternDemand = scanPatternDemand;
        SimulationClock = simulationClock;
        ScanStateData = scanStateData;
    }

    public void Initialise(double time)
    {
        ScanStateDataList = new List<ScanStateData>();
    }

    public void Update(double time)
    {
        var timeStamp = SimulationClock.GetTimeStamp(time);

        ScanStateData = ScanStateData with { TimeStamp = timeStamp };

        ScanStateDataList.Add(ScanStateData);
    }

    public void Finalise(double time)
    {
    }
}