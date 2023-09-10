namespace GOAP.Test.Movement
{
    public class IsInterestHasCollectableValue : IRequirement<WorldState>
    {
        private readonly PropertyId _interest;

        public IsInterestHasCollectableValue(PropertyId interest)
        {
            _interest = interest;
        }
        
        public int MismatchCost(WorldState state)
        {
            return state.Interests[_interest].CollectableValue > 0 ? 0 : 100;
        }
    }
}