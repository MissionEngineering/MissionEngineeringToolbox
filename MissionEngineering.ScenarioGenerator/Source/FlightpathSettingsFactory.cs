﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionEngineering.MathLibrary;

namespace MissionEngineering.ScenarioGenerator;

public static class FlightpathSettingsFactory
{
    public static FlightpathSettings FlightpathSettings_Test_1()
    {
        var flightpathSettings = new FlightpathSettings()
        {
            FlightpathId = 1,
            FlightpathName = "Flightpath_1",
            PositionNED = new PositionNED(10000.0, 5000.0, -2000.0),
            VelocityNED = new VelocityNED(-200.0, 100.0, -10.0)
        };

        return flightpathSettings;
    }

    public static FlightpathSettings FlightpathSettings_Test_2()
    {
        var flightpathSettings = new FlightpathSettings()
        {
            FlightpathId = 2,
            FlightpathName = "Flightpath_2",
            PositionNED = new PositionNED(20000.0, 25000.0, -12000.0),
            VelocityNED = new VelocityNED(250.0, -200.0, -15.0)
        };

        return flightpathSettings;
    }
}
