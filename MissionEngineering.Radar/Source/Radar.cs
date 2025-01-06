using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.Radar;

public class Radar : IRadar
{
    public int SensorId { get; set; }

    public string SensorName { get; set; }

    public SensorType SensorType => SensorType.Radar;
}
