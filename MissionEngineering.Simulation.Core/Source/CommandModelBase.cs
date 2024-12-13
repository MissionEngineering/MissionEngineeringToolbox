using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.Simulation.Core;

public abstract class CommandModelBase : ICommandModel
{
    public IModelState ModelState { get; set; }

    public void ProcessCommand(IModelCommand modelCommand)
    {
        ModelState = ProcessCommand(ModelState, modelCommand);
    }

    public IModelState ProcessCommand(IModelState modelState, IModelCommand modelCommand)
    {
        var modelEvents = Decide(modelState, modelCommand);

        modelState = Evolve(modelState, modelEvents);

        return modelState;
    }

    public abstract List<IModelEvent> Decide(IModelState modelState, IModelCommand modelCommand);

    public abstract IModelState Evolve(IModelState modelState, IModelEvent modelEvent);

    public IModelState Evolve(IModelState modelState, List<IModelEvent> modelEvents)
    {
        foreach (var modelEvent in modelEvents)
        {
            modelState = Evolve(modelState, modelEvent);
        }

        return modelState;
    }
}
