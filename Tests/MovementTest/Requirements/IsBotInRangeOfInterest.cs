using UnityEngine;

namespace GOAP.Test.Movement
{
    public class IsBotInRangeOfInterest : IRequirement<WorldState>
    {
        private readonly PropertyId _interest;
        private readonly float _appropriateRange;
        private readonly float _costPerUnit;

        public IsBotInRangeOfInterest(PropertyId interest, float appropriateRange, float costPerUnit = 1)
        {
            _interest = interest;
            _appropriateRange = appropriateRange;
            _costPerUnit = costPerUnit;
        }
        
        public int MismatchCost(WorldState state)
        {
            var botState = state.Bot;
            var interestState = state.Interests[_interest];
            float distance = Vector3.Distance(botState.Position, interestState.Position) - _appropriateRange;
            
            if (distance <= 0f)
            {
                return 0;
            }

            return Mathf.CeilToInt(distance * _costPerUnit);
        }
    }
}