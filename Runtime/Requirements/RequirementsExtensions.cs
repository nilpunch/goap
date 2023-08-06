using Common;

namespace GOAP
{
    public static class RequirementsExtensions
    {
        public static bool IsSatisfied(this IRequirement requirement, IReadOnlyState state) => requirement.MismatchCost(state) == 0;
    }
}