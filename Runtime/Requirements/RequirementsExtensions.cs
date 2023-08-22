namespace GOAP
{
    public static class RequirementsExtensions
    {
        public static bool IsSatisfied<TState>(this IRequirement<TState> requirement, TState state) => requirement.MismatchCost(state) == 0;
    }
}