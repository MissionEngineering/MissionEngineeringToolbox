namespace MissionEngineering.Radar;

public interface ISensor
{
    int SensorId { get; set; }

    string SensorName { get; set; }

    SensorType SensorType {  get; }
}