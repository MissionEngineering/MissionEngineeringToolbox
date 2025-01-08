using System.Text;
using MissionEngineering.Core;
using MissionEngineering.Scenario;
using MissionEngineering.Simulation;

namespace MissionEngineering.SimdisLibrary;

public class SimdisExporter : ISimdisExporter
{
    public SimulationData SimulationData { get; set; }

    public StringBuilder SimdisData { get; set; }

    public SimdisExporter(SimulationData simulationData)
    {
        SimulationData = simulationData;
        SimdisData = new StringBuilder();
    }

    public void GenerateSimdisData()
    {
        CreateSimdisHeader();

        CreatePlatforms();
    }

    public void WriteSimdisData()
    {
        if (!SimulationData.SimulationSettings.IsWriteData)
        {
            return;
        }

        var fileName = $"{SimulationData.SimulationSettings.SimulationName}.asi";

        var fileNameFull = SimulationData.SimulationSettings.GetFileNameFull(fileName);

        LogUtilities.LogInformation($"Writing Asi  File : {fileNameFull}");

        var strings = SimdisData.ToString();

        File.WriteAllText(fileNameFull, strings);
    }

    public void CreateSimdisHeader()
    {
        var llaOrigin = SimulationData.ScenarioSettings.LLAOrigin;

        AddLine("Version          24");
        AddLine("""Classification   "Unclassified" 0x8000FF00""");
        AddLine(@$"ScenarioInfo     ""{SimulationData.SimulationSettings.SimulationName}"" ");
        AddLine("""VerticalDatum    "WGS84" """);
        AddLine("""CoordSystem      "LLA" """);
        AddLine($"RefLLA           {llaOrigin.LatitudeDeg} {llaOrigin.LongitudeDeg} {llaOrigin.Altitude}");
        AddLine("""ReferenceTimeECI "0.0" """);
        AddLine("DegreeAngles     1");
        AddLine("");
    }

    public void CreatePlatforms()
    {
        var index = 0;

        foreach (var flightpathSettings in SimulationData.ScenarioSettings.FlightpathSettingsList)
        {
            var flightpathId = flightpathSettings.FlightpathId;

            var platformId = GetPlatformId(flightpathId);

            var flightpathStateDataList = SimulationData.FlightpathStateDataPerFlightpath[index];

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
        var platformSettings = flightpathSettings.PlatformSettings;

        AddLine(@$"PlatformID          {platformId}");
        AddLine(@$"PlatformName        {platformId} ""{flightpathSettings.FlightpathName}""");
        AddLine(@$"PlatformType        {platformId} ""{platformSettings.PlatformType}""");
        AddLine(@$"PlatformIcon        {platformId} ""{platformSettings.PlatformIcon}""");
        AddLine(@$"PlatformFHN         {platformId} {platformSettings.PlatformFHN}");
        AddLine(@$"PlatformInterpolate {platformId} {platformSettings.PlatformInterpolate}");
        AddLine(@$"PlatformCoordSystem {platformId} ""NED""");
        AddLine("");
        AddLine(@$"GenericData         {platformId} ""SIMDIS_DynamicScale"" ""1"" ""0"" ");
        AddLine(@$"GenericData         {platformId} ""SIMDIS_ScaleLevel"" ""{platformSettings.PlatformScaleLevel}"" ""0"" ");
        AddLine("");
    }

    public void CreatePlatformData(int platformId, List<FlightpathStateData> flightpathStateDataList)
    {
        foreach (var fd in flightpathStateDataList)
        {
            var time = fd.TimeStamp.Time;
            var lla = fd.PositionLLA;
            var pos = fd.PositionNED;
            var vel = fd.VelocityNED;
            var att = fd.Attitude;

            string line = $"PlatformData {platformId} {time} {pos.PositionNorth} {pos.PositionEast} {pos.PositionDown} {att.HeadingAngleDeg} {att.PitchAngleDeg} {att.BankAngleDeg} {vel.VelocityNorth} {vel.VelocityEast} {vel.VelocityDown}";

            AddLine(line);
        }

        AddLine("");
    }

    public void AddLine(string line)
    {
        SimdisData.AppendLine(line);
    }
}