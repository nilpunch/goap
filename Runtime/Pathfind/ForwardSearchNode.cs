using System.Collections.Generic;
using System.Linq;
using Common;
using GOAP.GoapPathfind.AStar;

namespace GOAP.GoapPathfind
{
    public class ForwardSearchNode : INode
    {
        private readonly IReadOnlyState _state;
        private readonly IRequirement _goal;
        private readonly IActionsLibrary _actionsLibrary;

        public static int NodesOutgo { get; set; }
        
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
                foreach (var action in _actionsLibrary.Actions
                             .Concat(_actionsLibrary.Actions.SelectMany(action => action.Requirement.ActionsToHelpSatisfy(_state).Actions))
                             .Concat(_goal.ActionsToHelpSatisfy(_state).Actions))
                {
                    NodesOutgo += 1;
                    
                    if (!action.Requirement.IsSatisfied(_state) || !action.Effect.IsChangeSomething(_state))
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
            return _state.ToString();
        }
    }
}