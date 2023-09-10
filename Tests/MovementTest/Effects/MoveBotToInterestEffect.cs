namespace GOAP.Test.Movement
{
    public class MoveBotToInterestEffect : IEffect<WorldState>
    {
        private readonly PropertyId _interest;

        public MoveBotToInterestEffect(PropertyId interest)
        {
            _interest = interest;
        }
        
        public WorldState Modify(WorldState state)
        {
            var newBotState = state.Bot;
            newBotState.Position = state.Interests[_interest].Position;
            
            return new WorldState(newBotState, state.Interests);
        }

        public bool IsChangeSomething(WorldState state)
        {
            var botState = state.Bot;
            var interestState = state.Interests[_interest];
            return !botState.Position.Equals(interestState.Position);
        }
    }
}