using System.Collections.Generic;

public interface IActionsLibrary
{
    IEnumerable<IAction> Actions { get; }
}