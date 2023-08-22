using Common;

namespace GOAP
{
    public class CollectValueEffect : IEffect<IReadOnlyBlackboard>
    {
        private readonly PropertyId _bot;
        private readonly PropertyId _interest;

        public CollectValueEffect(PropertyId bot, PropertyId interest)
        {
            _bot = bot;
            _interest = interest;
        }
        
        public IReadOnlyBlackboard Modify(IReadOnlyBlackboard state)
        {
            var botState = state.Get<BotState>(_bot);
            var interestState = state.Get<InterestState>(_interest);

            botState.CollectedValue += interestState.CollectableValue;
            interestState.CollectableValue = 0;

            var newState = state.Clone();
            newState.Set(_bot, botState);
            newState.Set(_interest, interestState);

            return newState;
        }

        public bool IsChangeSomething(IReadOnlyBlackboard state)
        {
            return state.Get<InterestState>(_interest).CollectableValue != 0;
        }
    }
}