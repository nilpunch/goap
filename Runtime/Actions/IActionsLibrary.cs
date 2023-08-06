using System.Collections.Generic;

namespace GOAP.Actions
{
    public interface IActionsLibrary
    {
        IEnumerable<IAction> Actions { get; }
    }
}