using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    public class Requirements<TState> : IRequirement<TState>
    {
        private readonly List<IRequirement<TState>> _requirements;

        public Requirements(IEnumerable<IRequirement<TState>> requirements)
        {
            _requirements = new List<IRequirement<TState>>(requirements);
        }

        public int MismatchCost(TState state)
        {
            return _requirements.Sum(requirement => requirement.MismatchCost(state));
        }

        public override string ToString()
        {
            return string.Join(", ", _requirements.Select(requirement => requirement.ToString()));
        }
    }
}