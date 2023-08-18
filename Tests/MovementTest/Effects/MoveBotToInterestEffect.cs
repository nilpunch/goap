using Common;

namespace GOAP
{
    public class MoveBotToInterestEffect : IEffect
    {
        private readonly PropertyId _bot;
        private readonly PropertyId _interest;

        public MoveBotToInterestEffect(PropertyId bot, PropertyId interest)
        {
            _bot = bot;
            _interest = interest;
        }
        
        public void Modify(IState state)
        {
            var botState = state.Get<BotState>(_bot);
            botState.Position = state.Get<InterestState>(_interest).Position;
            state.Set(_bot, botState);
        }

        public bool IsChangeSomething(IReadOnlyState state)
        {
            var botState = state.Get<BotState>(_bot);
            var interestState = state.Get<InterestState>(_interest);
            return !botState.Position.Equals(interestState.Position);
        }
    }
}