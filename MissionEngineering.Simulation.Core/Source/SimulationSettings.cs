namespace MissionEngineering.Simulation.Core;

public class SimulationSettings
{
    public string OutputFolder { get; set; }

    public string SimulationName { get; set; }

    public int RunNumber { get; set; }

    public DateTime DateTime { get; set; }

    public bool IsWriteData { get; set; }

    public bool IsAddTimeStamp { get; set; }

    public bool IsAddRunNumber { get; set; }

    public bool IsCreateZipFile { get; set; }

    public SimulationSettings()
    {
        OutputFolder = @"C:\Temp\MissionEngineeringToolbox\";
        SimulationName = "Simulation_1";
        RunNumber = 1;
        DateTime = DateTime.UtcNow;
        IsWriteData = true;
        IsAddTimeStamp = false;
        IsAddRunNumber = false;
        IsCreateZipFile = false;
    }
}