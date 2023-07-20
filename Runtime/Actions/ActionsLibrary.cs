using System.Collections.Generic;
using System.Linq;

public class ActionsLibrary : IActionsLibrary
{
    private readonly Dictionary<PropertyId, List<IAction>> _actionsByEffects = new Dictionary<PropertyId, List<IAction>>();
    private readonly List<IAction> _actions = new List<IAction>();

    public IEnumerable<IAction> Actions => _actions;

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
        _actions.Add(action);
    }

    public IEnumerable<IAction> FindActionsThatAffect(IReadOnlyState state)
    {
        foreach (var propertyId in state.BoolProperties.Keys.Concat(state.IntProperties.Keys).Concat(state.FloatProperties.Keys))
        {
            if (_actionsByEffects.TryGetValue(propertyId, out var actions))
            {
                foreach (var action in actions)
                {
                    yield return action;
                }
            }
        }
    }
}