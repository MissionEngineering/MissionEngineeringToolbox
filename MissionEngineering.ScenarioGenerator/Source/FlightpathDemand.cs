namespace MissionEngineering.ScenarioGenerator;

public record FlightpathDemand
{
    public int FlightpathId { get; set; }

    public double Time { get; set; }

    public double HeadingAngleDemandDeg { get; set; }

    public double SpeedDemand { get; set; }

    public double AltitudeDemand { get; set; }
}