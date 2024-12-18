using MissionEngineering.Scenario;
using MissionEngineering.Simulation;

namespace MissionEngineering.DataRecorder;

public interface IDataRecorder
{
    SimulationData SimulationData { get; set; }

    void AddFlightpathStateData(FlightpathStateData flightpathStateData);

    void AddFlightpathStateData(List<FlightpathStateData> flightpathStateDataList);

    void Initialise(double time);

    void Finalise(double time);

    string GetFileNameFull(string fileName);
}