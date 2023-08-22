using Common;

namespace GOAP
{
    public class IsInterestHasCollectableValue : IRequirement<IReadOnlyBlackboard>
    {
        private readonly PropertyId _interest;

        public IsInterestHasCollectableValue(PropertyId interest)
        {
            _interest = interest;
        }
        
        public int MismatchCost(IReadOnlyBlackboard state)
        {
            return state.Get<InterestState>(_interest).CollectableValue > 0 ? 0 : 100;
        }
    }
}