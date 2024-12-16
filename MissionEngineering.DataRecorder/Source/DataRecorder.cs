using System.Security.Cryptography.X509Certificates;
using MissionEngineering.Core;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.DataRecorder;

public class DataRecorder : IDataRecorder
{
    public SimulationData SimulationData { get; set; }

    public DataRecorder(SimulationData simulationData)
    {
        SimulationData = simulationData;
    }

    public void Initialise(double time)
    {
        SimulationData.FlightpathStateDataAll = new List<FlightpathStateData>();
        SimulationData.FlightpathStateDataPerFlightpath = new List<List<FlightpathStateData>>();
    }

    public void Finalise(double time)
    {
        CreateFlightpathData();

        WriteJsonData();
        WriteCsvData();
    }

    public void AddFlightpathStateData(FlightpathStateData flightpathStateData)
    {
        SimulationData.FlightpathStateDataAll.Add(flightpathStateData);
    }

    public void AddFlightpathStateData(List<FlightpathStateData> flightpathStateDataList)
    {
        SimulationData.FlightpathStateDataAll.AddRange(flightpathStateDataList);
    }

    public void CreateFlightpathData()
    {
        foreach (var flightpathSettings in SimulationData.ScenarioSettings.FlightpathSettingsList)
        {
            var flightpathId = flightpathSettings.FlightpathId;

            var flightpathData = SimulationData.FlightpathStateDataAll.Where(s => s.FlightpathId == flightpathId).ToList();

            SimulationData.FlightpathStateDataPerFlightpath.Add(flightpathData);
        }
    }

    public void WriteJsonData()
    {
        if (!SimulationData.SimulationSettings.IsWriteData)
        {
            return;
        }

        WriteSimulationSettingsToJson();
        WriteScenarioSettingsToJson();
    }

    public void WriteSimulationSettingsToJson()
    {
        var fileName = $"{SimulationData.SimulationSettings.SimulationName}_SimulationSettings.json";

        var fileNameFull = GetFileNameFull(fileName);

        SimulationData.SimulationSettings.WriteToJsonFile(fileNameFull);
    }

    public void WriteScenarioSettingsToJson()
    {
        var fileName = $"{SimulationData.SimulationSettings.SimulationName}_ScenarioSettings.json";

        var fileNameFull = GetFileNameFull(fileName);

        SimulationData.ScenarioSettings.WriteToJsonFile(fileNameFull);
    }

    public void WriteCsvData()
    {
        if (!SimulationData.SimulationSettings.IsWriteData)
        {
            return;
        }

        WriteFlightpathDataAllToCsv();
        WriteFlightpathDataPerFlightpathToCsv();
    }

    public void WriteFlightpathDataAllToCsv()
    {
        var flightpathDataAll = SimulationData.FlightpathStateDataAll;

        var fileName = $"{SimulationData.SimulationSettings.SimulationName}_FlightpathData_All.csv";

        var fileNameFull = GetFileNameFull(fileName);

        flightpathDataAll.WriteToCsvFile(fileNameFull);
    }

    public void WriteFlightpathDataPerFlightpathToCsv()
    {
        int index = 0;

        foreach (var flightpathSettings in SimulationData.ScenarioSettings.FlightpathSettingsList)
        {
            var flightpathDataList = SimulationData.FlightpathStateDataPerFlightpath[index];

            var fileName = $"{SimulationData.SimulationSettings.SimulationName}_FlightpathData_{flightpathSettings.FlightpathName}.csv";

            var fileNameFull = GetFileNameFull(fileName);

            flightpathDataList.WriteToCsvFile(fileNameFull);

            index++;
        }
    }

    public string GetFileNameFull(string fileName)
    {
        var fileNameFull = Path.Combine(SimulationData.SimulationSettings.OutputFolder, fileName);

        return fileNameFull;
    }
}