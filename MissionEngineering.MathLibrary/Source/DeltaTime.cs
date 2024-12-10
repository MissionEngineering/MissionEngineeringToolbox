using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.MathLibrary;

public struct DeltaTime
{
    public double Time { get; set; }

    public DeltaTime(double time)
    {
        Time = time;
    }
}
