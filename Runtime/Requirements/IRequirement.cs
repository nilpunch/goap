namespace GOAP
{
    public interface IRequirement<TState>
    {
        int MismatchCost(TState state);
    }
}