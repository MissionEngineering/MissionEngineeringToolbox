using System.Collections.Generic;
using System.IO;
using MissionEngineering.Core;
using MissionEngineering.MathLibrary;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.ScenarioGenerator;

public class ScenarioGenerator : IScenarioGenerator
{
    public ScenarioSettings ScenarioSettings { get; set; }

    public ILLAOrigin LLAOrigin { get; set; }

    public ISimulationClock SimulationClock { get; set; }

    public IScenario Scenario { get; set; }

    public ScenarioGenerator(IScenario scenario, ILLAOrigin llaOrigin, ISimulationClock simulationClock)
    {
        Scenario = scenario;
        LLAOrigin = llaOrigin;
        SimulationClock = simulationClock;
    }

    public void Run()
    {
        var clockSettings = ScenarioSettings.SimulationClockSettings;

        var time = clockSettings.TimeStart;

        Initialise(time);

        while (time <= clockSettings.TimeEnd)
        {
            Update(time);

            time += clockSettings.TimeStep;
        }

        Finalise(time);
    }

    public void Initialise(double time)
    {
        LLAOrigin.PositionLLA = ScenarioSettings.LLAOrigin;

        SimulationClock.DateTimeOrigin.DateTime = ScenarioSettings.SimulationClockSettings.DateTimeOrigin;

        Scenario.ScenarioSettings = ScenarioSettings;

        Scenario.Initialise(time);
    }

    public void Update(double time)
    {
        Scenario.Update(time);
    }

    public void Finalise(double time)
    {
        Scenario.Finalise(time);
    }

    public List<FlightpathData> GetFlightpathDataAll()
    {
        var flightpathDataAll = new List<FlightpathData>();

        foreach (var flightpath in Scenario.FlightpathList)
        {
            flightpathDataAll.AddRange(flightpath.FlightpathDataList);
        }

        flightpathDataAll = flightpathDataAll.OrderBy(s => s.TimeStamp.Time).ThenBy(s => s.FlightpathId).ToList();

        return flightpathDataAll;
    }


    public void WriteToCsv(string path)
    {
        foreach (var flightpath in Scenario.FlightpathList)
        {
            var fileName = $"{Scenario.ScenarioSettings.ScenarioName}_{flightpath.FlightpathSettings.FlightpathName}.csv";

            var fileNameFull = Path.Combine(path, fileName);

            flightpath.FlightpathDataList.WriteToCsvFile(fileNameFull);
        }

        var flightpathDataAll = GetFlightpathDataAll();
        var fileNameAll = $"{Scenario.ScenarioSettings.ScenarioName}_FlightpathsAll.csv";
        var fileNameAllFull = Path.Combine(path, fileNameAll);

        flightpathDataAll.WriteToCsvFile(fileNameAllFull);
    }
}