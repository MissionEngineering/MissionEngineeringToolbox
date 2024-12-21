using MissionEngineering.Core;
using MissionEngineering.Scenario;
using MissionEngineering.SimdisLibrary;
using MissionEngineering.Simulation;

namespace MissionEngineering.DataRecorder;

public class DataRecorder : IDataRecorder
{
    public SimulationData SimulationData { get; set; }

    public ISimdisExporter SimdisExporter { get; set; }

    public DataRecorder(SimulationData simulationData, ISimdisExporter simdisExporter)
    {
        SimulationData = simulationData;
        SimdisExporter = simdisExporter;
    }

    public void Initialise(double time)
    {
        SimulationData.FlightpathStateDataAll = new List<FlightpathStateData>();
        SimulationData.FlightpathStateDataPerFlightpath = new List<List<FlightpathStateData>>();
    }

    public void Finalise(double time)
    {
        CreateFlightpathData();

        WriteData();
    }

    public void WriteData()
    {
        if (!SimulationData.SimulationSettings.IsWriteData)
        {
            return;
        }

        CreateOutputFolder();

        WriteJsonData();
        WriteCsvData();
        WriteSimdisData();
    }

    public void CreateOutputFolder()
    {
        if (Directory.Exists(SimulationData.SimulationSettings.OutputFolder))
        {
            return;
        }

        Directory.CreateDirectory(SimulationData.SimulationSettings.OutputFolder);
    }

    //public void AddFlightpathStateData(FlightpathStateData flightpathStateData)
    //{
    //    SimulationData.FlightpathStateDataAll.Add(flightpathStateData);
    //}

    //public void AddFlightpathStateData(List<FlightpathStateData> flightpathStateDataList)
    //{
    //    SimulationData.FlightpathStateDataAll.AddRange(flightpathStateDataList);
    //}

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
        WriteSimulationSettingsToJson();
        WriteScenarioSettingsToJson();
    }

    public void WriteCsvData()
    {
        WriteFlightpathDataAllToCsv();
        WriteFlightpathDataPerFlightpathToCsv();
    }

    public void WriteSimdisData()
    {
        SimdisExporter.GenerateSimdisData();
        SimdisExporter.WriteSimdisData();
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
        var fileNameFull = SimulationData.SimulationSettings.GetFileNameFull(fileName);

        return fileNameFull;
    }
}