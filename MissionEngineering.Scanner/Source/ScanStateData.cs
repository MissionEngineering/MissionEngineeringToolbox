using MissionEngineering.Simulation;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner;

public record ScanStateData
{
    public int ScannerId { get; set; }

    public string ScannerName { get; set; }

    public TimeStamp TimeStamp { get; init; }

    public int ScanPatternModificationId { get; set; }

    public int ScanPatternId { get; set; }

    public string ScanPatternName { get; set; }

    public int ScanNumber { get; set; }

    public int FrameNumber { get; set; }

    public int BarIndex { get; set; }

    public bool IsStartOfFrame { get; set; }

    public bool IsEndOfFrame { get; set; }

    public bool IsStartOfBar { get; set; }

    public bool IsEndOfBar { get; set; }

    public double AzimuthAngleDemandDeg { get; set; }

    public double ElevationAngleDemandDeg { get; set; }

    public double AzimuthRateDemandDeg { get; set; }

    public double ElevationRateDemandDeg { get; set; }

    public double AzimuthAngleDeg { get; set; }

    public double ElevationAngleDeg { get; set; }

    public double AzimuthAngleNorthDeg { get; set; }

    public double AzimuthRateDeg { get; set; }

    public double ElevationRateDeg { get; set; }

}
