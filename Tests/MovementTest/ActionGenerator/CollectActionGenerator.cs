using System.Collections.Generic;
using Common;

namespace GOAP
{
    public class CollectActionGenerator : IActionGenerator<IReadOnlyBlackboard>
    {
        private readonly PropertyId _bot;
        private readonly IEnumerable<PropertyId> _interests;
        private readonly float _collectRange;
        private readonly float _costPerUnit;

        public CollectActionGenerator(PropertyId bot, IEnumerable<PropertyId> interests, float collectRange, float costPerUnit)
        {
            _bot = bot;
            _interests = interests;
            _collectRange = collectRange;
            _costPerUnit = costPerUnit;
        }
        
        public IEnumerable<IAction<IReadOnlyBlackboard>> GenerateActions(IReadOnlyBlackboard state)
        {
            foreach (var interest in _interests)
            {
                yield return new Action<IReadOnlyBlackboard>(new Requirements<IReadOnlyBlackboard>(new IRequirement<IReadOnlyBlackboard>[]
                    {
                        new IsBotInRangeOfInterest(_bot, interest, _collectRange, _costPerUnit),
                        new IsInterestHasCollectableValue(interest),
                    }),
                    new CollectValueEffect(_bot, interest), 1, _bot + " Collect " + interest);
            }
        }
    }
}