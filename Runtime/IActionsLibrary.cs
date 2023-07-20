using System.Collections.Generic;

public interface IActionsLibrary
{
    IEnumerable<IAction> FindActionsThatAffect(IReadOnlyState state);
}