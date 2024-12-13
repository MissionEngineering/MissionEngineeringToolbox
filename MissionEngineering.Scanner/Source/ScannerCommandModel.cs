using MissionEngineering.Scanner.Source;
using MissionEngineering.Simulation.Core;

namespace MissionEngineering.Scanner;

public class ScannerCommandModel : CommandModelBase
{
    public IScanner Scanner { get; set; }

    public ScannerCommandModel(IScanner scanner)
    {
        Scanner = scanner;
    }

    public override List<IModelEvent> Decide(IModelState modelState, IModelCommand modelCommand)
    {
        var modelEvents = new List<IModelEvent>();

        switch (modelCommand.GetType())
        {
            case Type command when command == typeof(ScanStateInitialiseCommand):
                {
                    modelEvents = GetScanStateInitialisedEvent((ScanStateInitialiseCommand)modelCommand);
                    break;
                }
            case Type command when command == typeof(ScanPatternDemandUpdateCommand):
                {
                    modelEvents = GetScanPatternDemandUpdatedEvent((ScanPatternDemandUpdateCommand)modelCommand);
                    break;
                }
            default:
                {
                    break;
                }
        };

        return modelEvents;
    }

    public List<IModelEvent> GetScanStateInitialisedEvent(ScanStateInitialiseCommand command)
    {
        var e = new ScanStateInitialisedEvent() 
        {  
            ScanStateData = command.ScanStateData 
        };

        var events = new List<IModelEvent>() { e };

        return events;
    }

    public List<IModelEvent> GetScanPatternDemandUpdatedEvent(ScanPatternDemandUpdateCommand commmand)
    {
        var e = new ScanPatternDemandUpdatedEvent() { };

        var events = new List<IModelEvent>() { e };

        return events;
    }

    public override IModelState Evolve(IModelState modelState, IModelEvent modelEvent)
    {
        switch (modelEvent.GetType())
        {
            case Type command when command == typeof(ScanStateInitialisedEvent):
                {
                    modelState = ProcessScanStateInitialisedEvent((ScanStateData)modelState, (ScanStateInitialisedEvent)modelEvent);
                    break;
                }
            default:
                {
                    break;
                }
        };

        return modelState;
    }

    private ScanStateData ProcessScanStateInitialisedEvent(ScanStateData modelState, ScanStateInitialisedEvent modelEvent)
    {
        modelState = modelEvent.ScanStateData;

        return modelState;
}
}