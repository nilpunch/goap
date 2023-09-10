using UnityEngine;

namespace GOAP.Test.Movement
{
    public class CanBotMoveToInterest : IRequirement<WorldState>
    {
        private readonly PropertyId _interest;
        private readonly float _costPerUnit;

        public CanBotMoveToInterest(PropertyId interest, float costPerUnit = 1f)
        {
            _interest = interest;
            _costPerUnit = costPerUnit;
        }
        
        public int MismatchCost(WorldState state)
        {
            var botState = state.Bot;
            var interestState = state.Interests[_interest];
            var distance = Vector3.Distance(botState.Position, interestState.Position) - botState.MaxDistancePerMove;
            
            return distance <= 0f ? 0 : Mathf.CeilToInt(distance * _costPerUnit);
        }
    }
}