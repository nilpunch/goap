using System.Collections.Generic;

namespace GOAP
{
    public interface IActionsLibrary
    {
        IEnumerable<IAction> Actions { get; }
    }
}