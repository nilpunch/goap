using System.Collections.Generic;
using System.Linq;

public class BackwardSearchNode : INode
{
    private readonly IReadOnlyState _originalState;
    private readonly IReadOnlyState _goalState;
    private readonly IStateComparer _stateComparer;
    private readonly IActionsLibrary _actionsLibrary;

    public BackwardSearchNode(IReadOnlyState originalState, IReadOnlyState goalState, IStateComparer stateComparer, IActionsLibrary actionsLibrary)
    {
        _goalState = goalState;
        _originalState = originalState;
        _stateComparer = stateComparer;
        _actionsLibrary = actionsLibrary;
        DistanceToGoal = new Distance(_stateComparer.Difference(_goalState, _originalState));
    }

    public Distance DistanceToGoal { get; }

    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.FindActionsThatAffect(_goalState))
            {
                var modification = new State();
                action.Effect.Modify(modification);
                
                if (_stateComparer.Difference(modification, _goalState) != 0)
                    continue;

                var newGoalState = _goalState.ExceptEqualTo(modification);
                newGoalState.ApplyProperties(action.Requirement);

                yield return new ActionEdge(this,
                    new BackwardSearchNode(_originalState, newGoalState, _stateComparer, _actionsLibrary),
                    new Distance(action.Cost),
                    action.ToString());
            }
        }
    }

    public override string ToString()
    {
        return string.Join(", ", _originalState.BoolProperties.Select(pair => pair.Key + " = " + pair.Value));
    }
}