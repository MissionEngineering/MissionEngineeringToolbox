using MissionEngineering.MathLibrary;
using MissionEngineering.Scenario;

namespace MissionEngineering.Simulation;

public static class FlightpathSettingsFactory
{
    public static FlightpathSettings FlightpathSettings_Test_1()
    {
        var platformSettings = new PlatformSettings();

        var flightpathDynamics = new FlightpathDynamics();

        var flightpathSettings = new FlightpathSettings()
        {
            FlightpathId = 1,
            FlightpathName = "Flightpath_1",
            PositionNED = new PositionNED(10000.0, 5000.0, -2000.0),
            VelocityNED = new VelocityNED(-200.0, 100.0, -10.0),
            PlatformSettings = platformSettings,
            FlightpathDynamics = flightpathDynamics
        };

        return flightpathSettings;
    }

    public static FlightpathSettings FlightpathSettings_Test_2()
    {
        var platformSettings = new PlatformSettings()
        {
            PlatformIcon = "jas-39_gripen",
            PlatformScaleLevel = "5.0"
        };

        var flightpathDynamics = new FlightpathDynamics()
        {
            AxialAccelerationMaximum = 15.0,
            LateralAccelerationMaximum = 15.0,
            VerticalAccelerationMaximum = 15.0,
            BankAngleMaximumDeg = 50.0
        };

        var flightpathSettings = new FlightpathSettings()
        {
            FlightpathId = 2,
            FlightpathName = "Flightpath_2",
            PositionNED = new PositionNED(20000.0, 25000.0, -12000.0),
            VelocityNED = new VelocityNED(250.0, -200.0, -15.0),
            PlatformSettings = platformSettings,
            FlightpathDynamics = flightpathDynamics
        };

        return flightpathSettings;
    }
}