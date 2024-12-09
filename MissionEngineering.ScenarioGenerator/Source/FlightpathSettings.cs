using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.ScenarioGenerator;

public record FlightpathSettings
{
    public int FlightpathId { get; init; }

    public string FlightpathName { get; init; } = string.Empty;

    public double TimeStart { get; init; }

    public double TimeEnd { get; init; }

    public double TimeStep { get; init; }
}
