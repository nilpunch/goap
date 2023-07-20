using System.Collections.Generic;
using System.Linq;

public class ActionsLibrary : IActionsLibrary
{
    private readonly Dictionary<PropertyId, List<IAction>> _actionsByEffects; 

    public void Add(IAction action)
    {
        foreach (var propertyId in action.Effect.AffectedProperties)
        {
            if (!_actionsByEffects.TryGetValue(propertyId, out var actions))
            {
                actions = new List<IAction>();
                _actionsByEffects.Add(propertyId, actions);
            }
            _actionsByEffects[propertyId].Add(action);
        }
    }
    
    public IEnumerable<IAction> FindActionsThatAffect(IReadOnlyState state)
    {
        foreach (var propertyId in state.BoolProperties.Keys.Concat(state.IntProperties.Keys).Concat(state.FloatProperties.Keys))
        {
            foreach (var action in _actionsByEffects[propertyId])
            {
                yield return action;
            }
        }
    }
}