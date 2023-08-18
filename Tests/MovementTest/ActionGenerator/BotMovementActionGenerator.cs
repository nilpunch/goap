using System.Collections.Generic;
using Common;
using UnityEngine;

namespace GOAP
{
    public class BotMovementActionGenerator : IActionGenerator
    {
        private readonly PropertyId _bot;
        private readonly PropertyId[] _interests;
        private readonly float _costPerUnit;

        public BotMovementActionGenerator(PropertyId bot, PropertyId[] interests, float costPerUnit)
        {
            _bot = bot;
            _interests = interests;
            _costPerUnit = costPerUnit;
        }
        
        public IEnumerable<IAction> GenerateActions(IReadOnlyState state)
        {
            var botState = state.Get<BotState>(_bot);
            
            foreach (var interest in _interests)
            {
                var interestState = state.Get<InterestState>(interest);
            
                float neededMovement = Vector3.Distance(botState.Position, interestState.Position);

                yield return new Action(
                    new CanBotMoveToInterest(_bot, interest, _costPerUnit),
                    new MoveBotToInterestEffect(_bot, interest), Mathf.CeilToInt(neededMovement * _costPerUnit), _bot + " -> " + interest);
            }
        }
    }
}