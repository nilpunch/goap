using System.Collections.Generic;
using System.Linq;
using Common;

namespace GOAP
{
    public class Requirements : IRequirement
    {
        private readonly List<IRequirement> _requirements;

        public Requirements(IEnumerable<IRequirement> requirements)
        {
            _requirements = new List<IRequirement>(requirements);
        }

        public int MismatchCost(IReadOnlyState state)
        {
            return _requirements.Sum(requirement => requirement.MismatchCost(state));
        }

        public override string ToString()
        {
            return string.Join(", ", _requirements.Select(requirement => requirement.ToString()));
        }
    }
}