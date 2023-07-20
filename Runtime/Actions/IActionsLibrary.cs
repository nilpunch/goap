using System.Collections.Generic;

public interface IActionsLibrary
{
    IEnumerable<IAction> Actions { get; }
    IEnumerable<IAction> FindActionsThatAffect(IReadOnlyState state);
}