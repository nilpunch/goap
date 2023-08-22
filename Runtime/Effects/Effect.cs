using System.Linq;

namespace GOAP
{
    public class Effect<TState> : IEffect<TState>
    {
        private readonly IEffect<TState>[] _effects;

        public Effect(IEffect<TState>[] effects)
        {
            _effects = effects;
        }

        public TState Modify(TState state)
        {
            return _effects.Aggregate(state, (current, effect) => effect.Modify(current));
        }

        public bool IsChangeSomething(TState state)
        {
            return _effects.Any(effect => effect.IsChangeSomething(state));
        }
    }
}