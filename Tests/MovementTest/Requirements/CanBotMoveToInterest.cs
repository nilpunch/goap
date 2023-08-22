using Common;
using UnityEngine;

namespace GOAP
{
    public class CanBotMoveToInterest : IRequirement<IReadOnlyBlackboard>
    {
        private readonly PropertyId _bot;
        private readonly PropertyId _interest;
        private readonly float _costPerUnit;

        public CanBotMoveToInterest(PropertyId bot, PropertyId interest, float costPerUnit)
        {
            _bot = bot;
            _interest = interest;
            _costPerUnit = costPerUnit;
        }
        
        public int MismatchCost(IReadOnlyBlackboard state)
        {
            var botState = state.Get<BotState>(_bot);
            var interestState = state.Get<InterestState>(_interest);
            float distance = Vector3.Distance(botState.Position, interestState.Position) - botState.MaxDistancePerMove;
            
            if (distance <= 0f)
            {
                return 0;
            }

            return Mathf.CeilToInt(distance * _costPerUnit);
        }
    }
}