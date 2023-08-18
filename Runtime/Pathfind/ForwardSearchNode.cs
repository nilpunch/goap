using System.Collections.Generic;
using Common;
using GOAP.AStar;

namespace GOAP
{
    public class ForwardSearchNode : INode
    {
        private readonly IReadOnlyState _state;
        private readonly IRequirement _goal;
        private readonly IActionGenerator _actionGenerator;

        public static int NodesOutgo { get; set; }
        
        public ForwardSearchNode(IReadOnlyState state, IRequirement goal, IActionGenerator actionGenerator)
        {
            _state = state;
            _goal = goal;
            _actionGenerator = actionGenerator;
            DistanceToGoal = new Distance(_goal.MismatchCost(_state));
        }

        public Distance DistanceToGoal { get; }

        public IEnumerable<IEdge> Outgoing
        {
            get
            {
                foreach (var action in _actionGenerator.GenerateActions(_state))
                {
                    NodesOutgo += 1;
                    
                    if (!action.Requirement.IsSatisfied(_state) || !action.Effect.IsChangeSomething(_state))
                        continue;
                
                    var newState = _state.Clone();
                    action.Effect.Modify(newState);

                    yield return new ActionEdge(this,
                        new ForwardSearchNode(newState, _goal, _actionGenerator),
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