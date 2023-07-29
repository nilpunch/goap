using System.Collections.Generic;
using System.Linq;

public class RegressionSearchNode : INode
{
    private readonly IReadOnlyAssignments _originalAssignments;
    private readonly IRequirement _goal;
    private readonly IActionsLibrary _actionsLibrary;

    public RegressionSearchNode(IReadOnlyAssignments originalAssignments, IRequirement goal, IActionsLibrary actionsLibrary)
    {
        _goal = goal;
        _originalAssignments = originalAssignments;
        _actionsLibrary = actionsLibrary;
        DistanceToGoal = new Distance(_goal.MismatchCost(_originalAssignments));
    }

    public Distance DistanceToGoal { get; }

    public IEnumerable<IEdge> Outgoing
    {
        get
        {
            foreach (var action in _actionsLibrary.Actions)
            {
                var approximateGoalAssignments = new Assignments();
                _goal.MakeSatisfactionAssignment(approximateGoalAssignments);

                var assignmentsAfterEffect = approximateGoalAssignments.Clone();
                action.Effect.Modify(assignmentsAfterEffect);
                
                if (_goal.IsRuined(assignmentsAfterEffect))
                    continue;
                
                var updatedGoal = _goal.GetUnsatisfiedReminder(approximateGoalAssignments, assignmentsAfterEffect);
                Requirements newGoal = new Requirements(new IRequirement[]
                {
                    action.Requirement,
                    updatedGoal
                });

                yield return new ActionEdge(this,
                    new RegressionSearchNode(_originalAssignments, newGoal, _actionsLibrary),
                    new Distance(action.Cost),
                    action.ToString());
            }
        }
    }

    public override string ToString()
    {
        return string.Join(", ", _originalAssignments.BoolProperties.Select(pair => pair.Key + " = " + pair.Value));
    }
}