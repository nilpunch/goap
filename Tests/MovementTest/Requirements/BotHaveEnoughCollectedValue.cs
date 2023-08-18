using Common;
using UnityEngine;

namespace GOAP
{
    public class BotHaveEnoughCollectedValue : IRequirement
    {
        private readonly PropertyId _bot;
        private readonly int _goalValue;
        private readonly int _mismatchMultiplier;

        public BotHaveEnoughCollectedValue(PropertyId bot, int goalValue, int mismatchMultiplier = 1)
        {
            _bot = bot;
            _goalValue = goalValue;
            _mismatchMultiplier = mismatchMultiplier;
        }
        
        public int MismatchCost(IReadOnlyState state)
        {
            var botState = state.Get<BotState>(_bot);
            return Mathf.Max(0, _goalValue - botState.CollectedValue) * _mismatchMultiplier;
        }
    }
}