using MissionEngineering.MathLibrary;

namespace MissionEngineering.ScenarioGenerator;

public interface IFlightpathAccelerationGenerator
{
    AccelerationTBA GetAccelerationTBA(double time);
}