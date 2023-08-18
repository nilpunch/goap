using Common;
using UnityEngine;

namespace GOAP
{
    public class IsBotInRangeOfInterest : IRequirement
    {
        private readonly PropertyId _bot;
        private readonly PropertyId _interest;
        private readonly float _appropriateRange;
        private readonly float _costPerUnit;

        public IsBotInRangeOfInterest(PropertyId bot, PropertyId interest, float appropriateRange, float costPerUnit)
        {
            _bot = bot;
            _interest = interest;
            _appropriateRange = appropriateRange;
            _costPerUnit = costPerUnit;
        }
        
        public int MismatchCost(IReadOnlyState state)
        {
            var botState = state.Get<BotState>(_bot);
            var interestState = state.Get<InterestState>(_interest);
            float distance = Vector3.Distance(botState.Position, interestState.Position) - _appropriateRange;
            
            if (distance <= 0f)
            {
                return 0;
            }

            return Mathf.CeilToInt(distance * _costPerUnit);
        }
    }
}