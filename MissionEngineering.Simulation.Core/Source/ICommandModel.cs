using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.Simulation.Core;

public interface ICommandModel
{
    IModelState ModelState { get; }

    void ProcessCommand(IModelCommand modelCommand);

    IModelState ProcessCommand(IModelState modelState, IModelCommand modelCommand);

    List<IModelEvent> Decide(IModelState modelState, IModelCommand modelCommand);

    IModelState Evolve(IModelState modelState, IModelEvent modelEvent);

    IModelState Evolve(IModelState modelState, List<IModelEvent> modelEvents);
}
