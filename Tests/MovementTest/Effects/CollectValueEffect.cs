namespace GOAP.Test.Movement
{
    public class CollectValueEffect : IEffect<WorldState>
    {
        private readonly PropertyId _interest;

        public CollectValueEffect(PropertyId interest)
        {
            _interest = interest;
        }
        
        public WorldState Modify(WorldState state)
        {
            var newBotState = state.Bot;
            var newInterestState = state.Interests[_interest];
            newBotState.CollectedValue += newInterestState.CollectableValue;
            newInterestState.CollectableValue = 0;

            var newInterests = state.Interests.CloneAsWriteable();
            newInterests[_interest] = newInterestState;

            return new WorldState(newBotState, newInterests);
        }

        public bool IsChangeSomething(WorldState state)
        {
            return state.Interests[_interest].CollectableValue != 0;
        }
    }
}