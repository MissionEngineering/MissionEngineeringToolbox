﻿using MissionEngineering.Scenario;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.DataRecorder;

public class SimulationData
{
    public SimulationSettings SimulationSettings { get; set; }

    public ScenarioSettings ScenarioSettings { get; set; }

    public List<FlightpathStateData> FlightpathStateDataAll { get; set; }

    public List<List<FlightpathStateData>> FlightpathStateDataPerFlightpath { get; set; }

    public SimulationData(SimulationSettings simulationSettings, ScenarioSettings scenarioSettings)
    {
        SimulationSettings = simulationSettings;
        ScenarioSettings = scenarioSettings;
    }
}