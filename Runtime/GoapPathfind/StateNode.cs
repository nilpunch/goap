using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StateNode : INode
{
    private readonly IReadOnlyState _currentState;
    private readonly IReadOnlyState _goalState;
    private readonly IStateComparer _stateComparer;
    private readonly IActionsLibrary _actionsLibrary;

    public StateNode(IReadOnlyState currentState, IReadOnlyState goalState, IStateComparer stateComparer, IActionsLibrary actionsLibrary)
    {
        _currentState = currentState;
        _goalState = goalState;
        _stateComparer = stateComparer;
        _actionsLibrary = actionsLibrary;
        DistanceToGoal = new Distance(_stateComparer.HowHardToEqualize(_goalState, _currentState));
    }

    public Distance DistanceToGoal { get; }

    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.Actions)
            {
                if (_stateComparer.HowHardToEqualize(action.Requirement, _currentState) != 0)
                    continue;
                
                var newCurrentState = _currentState.Clone();
                action.Effect.Modify(newCurrentState);

                yield return new ActionEdge(this,
                    new StateNode(newCurrentState, _goalState, _stateComparer, _actionsLibrary),
                    new Distance(action.Cost),
                    action.ToString());
            }
        }
    }

    public override string ToString()
    {
        return string.Join(", ", _currentState.BoolProperties.Select(pair => pair.Key + " = " + pair.Value));
    }
}