using UnityEngine;

namespace GOAP.Test.Movement
{
    public class BotHaveEnoughCollectedValue : IRequirement<WorldState>
    {
        private readonly int _goalValue;
        private readonly int _mismatchMultiplier;

        public BotHaveEnoughCollectedValue(int goalValue, int mismatchMultiplier = 1)
        {
            _goalValue = goalValue;
            _mismatchMultiplier = mismatchMultiplier;
        }
        
        public int MismatchCost(WorldState state)
        {
            var botState = state.Bot;
            return Mathf.Max(0, _goalValue - botState.CollectedValue) * _mismatchMultiplier;
        }
    }
}