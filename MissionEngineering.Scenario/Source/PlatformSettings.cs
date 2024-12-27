using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.Scenario;

public record PlatformSettings
{
   public string PlatformType {  get; init; }
    
    public string PlatformIcon { get; init; }

    public string PlatformFHN { get; init; }

    public string PlatformInterpolate { get; init; }

    public string PlatformScaleLevel { get; init; }

    public PlatformSettings()
    {
        PlatformType = "aircraft";
        PlatformIcon = "f-35a_lightning";
        PlatformFHN = "F";
        PlatformInterpolate = "1";
        PlatformScaleLevel = "4.0";
    }
}
