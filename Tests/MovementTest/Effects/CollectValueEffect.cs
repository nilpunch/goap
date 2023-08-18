using Common;

namespace GOAP
{
    public class CollectValueEffect : IEffect
    {
        private readonly PropertyId _bot;
        private readonly PropertyId _interest;

        public CollectValueEffect(PropertyId bot, PropertyId interest)
        {
            _bot = bot;
            _interest = interest;
        }
        
        public void Modify(IState state)
        {
            var botState = state.Get<BotState>(_bot);
            var interestState = state.Get<InterestState>(_interest);

            botState.CollectedValue += interestState.CollectableValue;
            interestState.CollectableValue = 0;
            
            state.Set(_bot, botState);
            state.Set(_interest, interestState);
        }

        public bool IsChangeSomething(IReadOnlyState state)
        {
            return state.Get<InterestState>(_interest).CollectableValue != 0;
        }
    }
}