using Common;

namespace GOAP
{
    public class SatisfiedRequirement : IRequirement
    {
        public int MismatchCost(IReadOnlyState state)
        {
            return 0;
        }
    }
}