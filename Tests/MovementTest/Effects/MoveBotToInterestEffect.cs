using Common;

namespace GOAP
{
    public class MoveBotToInterestEffect : IEffect<IReadOnlyBlackboard>
    {
        private readonly PropertyId _bot;
        private readonly PropertyId _interest;

        public MoveBotToInterestEffect(PropertyId bot, PropertyId interest)
        {
            _bot = bot;
            _interest = interest;
        }
        
        public IReadOnlyBlackboard Modify(IReadOnlyBlackboard state)
        {
            var botState = state.Get<BotState>(_bot);
            botState.Position = state.Get<InterestState>(_interest).Position;

            var newState = state.Clone();
            newState.Set(_bot, botState);

            return newState;
        }

        public bool IsChangeSomething(IReadOnlyBlackboard state)
        {
            var botState = state.Get<BotState>(_bot);
            var interestState = state.Get<InterestState>(_interest);
            return !botState.Position.Equals(interestState.Position);
        }
    }
}