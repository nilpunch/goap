using System.Collections.Generic;
using Common;
using UnityEngine;

namespace GOAP
{
    public class BotMovementActionGenerator : IActionGenerator<IReadOnlyBlackboard>
    {
        private readonly PropertyId _bot;
        private readonly IEnumerable<PropertyId> _interests;
        private readonly float _costPerUnit;

        public BotMovementActionGenerator(PropertyId bot, IEnumerable<PropertyId> interests, float costPerUnit)
        {
            _bot = bot;
            _interests = interests;
            _costPerUnit = costPerUnit;
        }
        
        public IEnumerable<IAction<IReadOnlyBlackboard>> GenerateActions(IReadOnlyBlackboard state)
        {
            var botState = state.Get<BotState>(_bot);
            
            foreach (var interest in _interests)
            {
                var interestState = state.Get<InterestState>(interest);
            
                float neededMovement = Vector3.Distance(botState.Position, interestState.Position);

                yield return new Action<IReadOnlyBlackboard>(
                    new CanBotMoveToInterest(_bot, interest, _costPerUnit),
                    new MoveBotToInterestEffect(_bot, interest), Mathf.CeilToInt(neededMovement * _costPerUnit), _bot + " Goto " + interest);
            }
        }
    }
}