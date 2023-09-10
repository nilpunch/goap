using System.Collections.Generic;
using UnityEngine;

namespace GOAP.Test.Movement
{
    public class BotMovementActionGenerator : IActionGenerator<WorldState>
    {
        private readonly PropertyId _bot;
        private readonly IEnumerable<PropertyId> _interests;
        private readonly float _costPerUnit;
        private readonly int _fixedCost;

        public BotMovementActionGenerator(PropertyId bot, IEnumerable<PropertyId> interests, float costPerUnit = 1f, int fixedCost = 1)
        {
            _bot = bot;
            _interests = interests;
            _costPerUnit = costPerUnit;
            _fixedCost = fixedCost;
        }
        
        public IEnumerable<IAction<WorldState>> GenerateActions(WorldState state)
        {
            var botState = state.Bot;
            
            foreach (var interest in _interests)
            {
                var interestState = state.Interests[interest];
            
                float neededMovement = Vector3.Distance(botState.Position, interestState.Position);

                yield return new Action<WorldState>(
                    new CanBotMoveToInterest(interest, _costPerUnit),
                    new MoveBotToInterestEffect(interest), Mathf.CeilToInt(neededMovement * _costPerUnit) + _fixedCost, botState + " Goto " + interestState);
            }
        }
    }
}