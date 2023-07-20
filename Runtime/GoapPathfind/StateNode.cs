using System.Collections.Generic;

public class StateNode : INode
{
    private readonly IState _currentState;
    private readonly IReadOnlyState _goalState;
    private readonly IStateComparer _stateComparer;
    private readonly IActionsLibrary _actionsLibrary;

    public StateNode(IState currentState, IReadOnlyState goalState, IStateComparer stateComparer, IActionsLibrary actionsLibrary)
    {
        _currentState = currentState;
        _goalState = goalState;
        _stateComparer = stateComparer;
        _actionsLibrary = actionsLibrary;
    }

    public Distance DistanceToGoal => new Distance(_stateComparer.HowHardToEqualize(_currentState, _goalState));
    
    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.FindActionsThatAffect(_currentState))
            {
                var newState = _currentState.Clone();
                action.Effect.Modify(newState);
                newState.ApplyProperties(action.Requirement);

                yield return new Edge(this,
                    new StateNode(newState, _goalState, _stateComparer, _actionsLibrary),
                    new Distance(action.Cost));
            }
        }
    }
}