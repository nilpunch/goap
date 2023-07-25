using System.Collections.Generic;
using System.Linq;

public class RegressionSearchNode : INode
{
    private readonly IReadOnlyState _originalState;
    private readonly IRequirement _goal;
    private readonly IActionsLibrary _actionsLibrary;

    public RegressionSearchNode(IReadOnlyState originalState, IRequirement goal, IActionsLibrary actionsLibrary)
    {
        _goal = goal;
        _originalState = originalState;
        _actionsLibrary = actionsLibrary;
        DistanceToGoal = new Distance(_goal.MismatchCost(_originalState));
    }

    public Distance DistanceToGoal { get; }

    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.Actions)
            {
                var approximateGoalState = new State();
                _goal.SatisfyState(approximateGoalState);

                var stateBeforeGoal = approximateGoalState.Clone();
                action.Effect.AntiModify(stateBeforeGoal);

                var change = _goal.MismatchCost(stateBeforeGoal);
                if (change <= 0)
                    continue;
                
                var updatedGoal = _goal.GetUnsatisfiedReminder(stateBeforeGoal, approximateGoalState);
                Requirements newGoal = new Requirements(new IRequirement[]
                {
                    action.Requirement,
                    updatedGoal
                });

                yield return new ActionEdge(this,
                    new RegressionSearchNode(_originalState, newGoal, _actionsLibrary),
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