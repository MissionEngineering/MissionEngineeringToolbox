using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Simulation;

public static class SimulationSettingsFactory
{
    public static SimulationSettings SimulationSettings_Test_1()
    {
        var simulationSettings = new SimulationSettings()
        {
            SimulationName = "Simulation_1",
            RunNumber = 1,
            DateTime = DateTime.Now,
            IsWriteData = true,
            IsAddTimeStamp = true,
            IsAddRunNumber = true,
            IsCreateZipFile = true,
            OutputFolderBase = @"C:\Temp\MissionEngineeringToolbox\"
        };

        return simulationSettings;
    }
}