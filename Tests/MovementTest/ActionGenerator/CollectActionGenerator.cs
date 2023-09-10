using System.Collections.Generic;

namespace GOAP.Test.Movement
{
    public class CollectActionGenerator : IActionGenerator<WorldState>
    {
        private readonly IEnumerable<PropertyId> _interests;
        private readonly float _collectRange;
        private readonly float _costPerUnit;

        public CollectActionGenerator(IEnumerable<PropertyId> interests, float collectRange, float costPerUnit)
        {
            _interests = interests;
            _collectRange = collectRange;
            _costPerUnit = costPerUnit;
        }
        
        public IEnumerable<IAction<WorldState>> GenerateActions(WorldState state)
        {
            foreach (var interest in _interests)
            {
                yield return new Action<WorldState>(new Requirements<WorldState>(new IRequirement<WorldState>[]
                    {
                        new IsBotInRangeOfInterest(interest, _collectRange, _costPerUnit),
                        new IsInterestHasCollectableValue(interest),
                    }),
                    new CollectValueEffect(interest), 1, state.Bot + " Collect " + state.Interests[interest]);
            }
        }
    }
}