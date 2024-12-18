namespace MissionEngineering.Scanner;

public record ScanPatternDemand
{
    public int ScanPatternId { get; set; }

    public int ScanPatternModificationId { get; set; }

    public string ScanPatternName { get; set; }

    public double AzimuthCentreDeg { get; set; }

    public double AzimuthWidthDeg { get; set; }

    public double AzimuthHalfWidthDeg => AzimuthWidthDeg / 2.0;

    public double AzimuthMinimumDeg => AzimuthCentreDeg - AzimuthHalfWidthDeg;

    public double AzimuthMaximumDeg => AzimuthCentreDeg + AzimuthHalfWidthDeg;

    public double NumberOfElevationBars { get; set; }

    public double ElevationCentreDeg { get; set; }

    public double ElevationBarSeparationDeg { get; set; }

    public double ElevationExtentDeg => (NumberOfElevationBars - 1) * ElevationBarSeparationDeg;

    public double ElevationMimimumDeg => ElevationCentreDeg - ElevationExtentDeg / 2.0;

    public double ElevationMaximumDeg => ElevationCentreDeg + ElevationExtentDeg / 2.0;
}