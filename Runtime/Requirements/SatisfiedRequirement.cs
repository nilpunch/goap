using Common;

namespace GOAP.Requirements
{
    public class SatisfiedRequirement : IRequirement
    {
        public int MismatchCost(IReadOnlySate sate)
        {
            return 0;
        }
    }
}