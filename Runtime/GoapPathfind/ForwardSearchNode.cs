using System.Collections.Generic;
using System.Linq;

public class ForwardSearchNode : INode
{
    private readonly IReadOnlyState _state;
    private readonly IRequirement _goal;
    private readonly IActionsLibrary _actionsLibrary;

    public ForwardSearchNode(IReadOnlyState state, IRequirement goal, IActionsLibrary actionsLibrary)
    {
        _state = state;
        _goal = goal;
        _actionsLibrary = actionsLibrary;
        DistanceToGoal = new Distance(_goal.MismatchCost(_state));
    }

    public Distance DistanceToGoal { get; }

    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.Actions)
            {
                if (!action.Requirement.IsSatisfied(_state))
                    continue;
                
                var newCurrentState = _state.Clone();
                action.Effect.Modify(newCurrentState);

                yield return new ActionEdge(this,
                    new ForwardSearchNode(newCurrentState, _goal, _actionsLibrary),
                    new Distance(action.Cost),
                    action.ToString());
            }
        }
    }

    public override string ToString()
    {
        return string.Join(", ", _state.BoolProperties.Select(pair => pair.Key + " = " + pair.Value));
    }
}