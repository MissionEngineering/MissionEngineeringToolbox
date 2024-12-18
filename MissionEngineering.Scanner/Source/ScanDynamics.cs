namespace MissionEngineering.Scanner;

public record ScanDynamics
{
    public double AzimuthRateMaximumDeg { get; set; }

    public double ElevationRateMaximumDeg { get; set; }

    public double AzimuthAccelerationMaximumDeg { get; set; }

    public double ElevationAccelerationMaximumDeg { get; set; }

    public double AzimuthRateGain { get; set; }

    public double AzimuthAccelerationGain { get; set; }

    public double ElevationRateGain { get; set; }

    public double ElevationAccelerationGain { get; set; }
}