using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionEngineering.DataRecorder;
using MissionEngineering.Scenario;

namespace MissionEngineering.SimdisLibrary;

public class SimdisExporter : ISimdisExporter
{
    public IDataRecorder DataRecorder { get; set; }

    public StringBuilder SimdisData { get; set; }

    public SimdisExporter(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void GenerateSimdisData()
    {
        SimdisData = new StringBuilder();

        CreateSimdisHeader();

        CreatePlatforms();
    }

    public void WriteSimdisData()
    {
        var fileName = $"{DataRecorder.SimulationData.SimulationSettings.SimulationName}.asi";

        var fileNameFull = DataRecorder.GetFileNameFull(fileName);

        var strings = SimdisData.ToString();

        File.WriteAllText(fileNameFull, strings);
    }

    public void CreateSimdisHeader()
    {
        AddLine("Version 24", true);

        var llaOrigin = DataRecorder.SimulationData.ScenarioSettings.LLAOrigin;

        AddLine($"RefLLA          {llaOrigin.LatitudeDeg} {llaOrigin.LongitudeDeg} {llaOrigin.Altitude}");
        AddLine("""CoordSystem      "LLA" """);
        AddLine("""Classification   "Unclassified" 0x8000FF00""");
        AddLine("DegreeAngles     1");
        AddLine("""VerticalDatum    "WGS84" """);
        AddLine("""ReferenceTimeECI "0.0" """);
        AddLine("");
    }

    public void CreatePlatforms()
    {
        var index = 0;

        foreach (var flightpathSettings in DataRecorder.SimulationData.ScenarioSettings.FlightpathSettingsList)
        {
            var flightpathId = flightpathSettings.FlightpathId;

            var platformId = GetPlatformId(flightpathId);

            var flightpathStateDataList = DataRecorder.SimulationData.FlightpathStateDataPerFlightpath[index];

            CreatePlatformInitialisation(platformId, flightpathSettings);

            CreatePlatformData(platformId, flightpathStateDataList);

            index++;
        }
    }

    public int GetPlatformId(int flightpathId)
    { 
        return flightpathId; 
    }

    public void CreatePlatformInitialisation(int platformId, FlightpathSettings flightpathSettings)
    {
        AddLine($"PlatformID          {platformId}");
        AddLine($"PlatformName        {platformId} {flightpathSettings.FlightpathName}");
        AddLine(@$"PlatformType        {platformId} ""aircraft""");
        AddLine($"PlatformFHN         {platformId} F");
        AddLine($"PlatformInterpolate {platformId} 1");
        AddLine(@$"PlatformIcon        {platformId} ""f-35a_lightning""");
        AddLine("");
    }

    public void CreatePlatformData(int platformId, List<FlightpathStateData> flightpathStateDataList)
    {
        foreach (var fd in flightpathStateDataList)
        {
            var time = fd.TimeStamp.Time;
            var lla = fd.PositionLLA;
            var vel = fd.VelocityNED;
            var att = fd.Attitude;

            string line = $"PlatformData {platformId} {time} {lla.LatitudeDeg} {lla.LongitudeDeg} {lla.Altitude} {att.HeadingAngleDeg} {att.PitchAngleDeg} {att.BankAngleDeg} {vel.VelocityNorth} {vel.VelocityEast} {vel.VelocityDown}";

            AddLine(line);
        }

        AddLine("");
    }

    public void AddLine(string line, bool isAddNewLine = false)
    {
        SimdisData.AppendLine(line);

        if (isAddNewLine)
        {
            SimdisData.Append(Environment.NewLine);
        }
    }

    public void AddLines(string[] lines)
    {
        SimdisData.Append(lines);
    }
}
