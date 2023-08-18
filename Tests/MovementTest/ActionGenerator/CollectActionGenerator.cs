using System.Collections.Generic;
using Common;

namespace GOAP
{
    public class CollectActionGenerator : IActionGenerator
    {
        private readonly PropertyId _bot;
        private readonly PropertyId[] _interests;
        private readonly float _collectRange;
        private readonly float _costPerUnit;

        public CollectActionGenerator(PropertyId bot, PropertyId[] interests, float collectRange, float costPerUnit)
        {
            _bot = bot;
            _interests = interests;
            _collectRange = collectRange;
            _costPerUnit = costPerUnit;
        }
        
        public IEnumerable<IAction> GenerateActions(IReadOnlyState state)
        {
            foreach (var interest in _interests)
            {
                yield return new Action(new Requirements(new IRequirement[]
                    {
                        new IsBotInRangeOfInterest(_bot, interest, _collectRange, _costPerUnit),
                        new IsInterestHasCollectableValue(interest),
                    }),
                    new CollectValueEffect(_bot, interest), 1, _bot + " Collect " + interest);
            }
        }
    }
}