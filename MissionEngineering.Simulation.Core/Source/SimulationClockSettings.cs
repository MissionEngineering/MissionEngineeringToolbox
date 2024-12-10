using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.Simulation.Core;

public record SimulationClockSettings
{
    public DateTime DateTimeOrigin { get; set; }

    public double TimeStart { get; set; }

    public double TimeEnd { get; set; }

    public double TimeStep { get; set; }
}
