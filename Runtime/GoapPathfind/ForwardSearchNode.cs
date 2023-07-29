using System.Collections.Generic;
using System.Linq;

public class ForwardSearchNode : INode
{
    private readonly IReadOnlyAssignments _assignments;
    private readonly IRequirement _goal;
    private readonly IActionsLibrary _actionsLibrary;

    public ForwardSearchNode(IReadOnlyAssignments assignments, IRequirement goal, IActionsLibrary actionsLibrary)
    {
        _assignments = assignments;
        _goal = goal;
        _actionsLibrary = actionsLibrary;
        DistanceToGoal = new Distance(_goal.MismatchCost(_assignments));
    }

    public Distance DistanceToGoal { get; }

    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.Actions)
            {
                if (!action.Requirement.IsSatisfied(_assignments))
                    continue;
                
                var newCurrentState = _assignments.Clone();
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
        return string.Join(", ", _assignments.BoolProperties.Select(pair => pair.Key + " = " + pair.Value));
    }
}