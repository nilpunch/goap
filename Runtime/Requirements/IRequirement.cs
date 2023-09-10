namespace GOAP
{
    public interface IRequirement<in TState>
    {
        int MismatchCost(TState state);
        bool IsSatisfied(TState state) => MismatchCost(state) == 0;
    }
}