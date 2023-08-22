using System;
using System.Collections.Generic;
using GOAP.AStar;

namespace GOAP
{
    public class ForwardSearchNode<TState> : INode, IEquatable<ForwardSearchNode<TState>>
    {
        private readonly TState _state;
        private readonly IRequirement<TState> _goal;
        private readonly IActionGenerator<TState> _actionGenerator;

        public ForwardSearchNode(TState state, IRequirement<TState> goal, IActionGenerator<TState> actionGenerator)
        {
            _state = state;
            _goal = goal;
            _actionGenerator = actionGenerator;
            Remain = new Cost(_goal.MismatchCost(_state));
        }

        public Cost Remain { get; }

        public IEnumerable<IEdge> Outgoing
        {
            get
            {
                foreach (var action in _actionGenerator.GenerateActions(_state))
                {
                    if (!action.Requirement.IsSatisfied(_state) || !action.Effect.IsChangeSomething(_state))
                        continue;
                
                    var newState = action.Effect.Modify(_state);

                    yield return new ActionEdge(this,
                        new ForwardSearchNode<TState>(newState, _goal, _actionGenerator),
                        new Cost(action.Cost),
                        action.ToString());
                }
            }
        }

        public override string ToString()
        {
            return _state.ToString();
        }

        public bool Equals(ForwardSearchNode<TState> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            return _state.Equals(other._state);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
        
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
        
            if (obj.GetType() != GetType())
            {
                return false;
            }
        
            return Equals((ForwardSearchNode<TState>)obj);
        }
        
        public override int GetHashCode()
        {
            return _state.GetHashCode();
        }
    }
}