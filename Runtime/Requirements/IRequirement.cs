using Common;

namespace GOAP.Requirements
{
    public interface IRequirement
    {
        int MismatchCost(IReadOnlySate sate);
        bool IsSatisfied(IReadOnlySate sate) => MismatchCost(sate) == 0;
    }
}