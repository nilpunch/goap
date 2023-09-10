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
            float distance = Vector3.Distance(botState.Position, interestState.Position) - botState.MaxDistancePerMove;
            
            if (distance <= 0f)
            {
                return 0;
            }

            return Mathf.CeilToInt(distance * _costPerUnit);
        }
    }
}