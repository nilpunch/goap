using Common;

namespace GOAP
{
    public class IsInterestHasCollectableValue : IRequirement
    {
        private readonly PropertyId _interest;

        public IsInterestHasCollectableValue(PropertyId interest)
        {
            _interest = interest;
        }
        
        public int MismatchCost(IReadOnlyState state)
        {
            return state.Get<InterestState>(_interest).CollectableValue > 0 ? 0 : 100;
        }
    }
}