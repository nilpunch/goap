using System.Collections.Generic;
using System.Linq;

public class ForwardSearchNode : INode
{
    private readonly IReadOnlySate _sate;
    private readonly IRequirement _goal;
    private readonly IActionsLibrary _actionsLibrary;

    public ForwardSearchNode(IReadOnlySate sate, IRequirement goal, IActionsLibrary actionsLibrary)
    {
        _sate = sate;
        _goal = goal;
        _actionsLibrary = actionsLibrary;
        DistanceToGoal = new Distance(_goal.MismatchCost(_sate));
    }

    public Distance DistanceToGoal { get; }

    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.Actions)
            {
                if (!action.Requirement.IsSatisfied(_sate) || !action.Effect.IsChangeSomething(_sate))
                    continue;
                
                var newCurrentState = _sate.Clone();
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
        return string.Join(", ", _sate.BoolProperties.Select(pair => pair.Key + " = " + pair.Value));
    }
}