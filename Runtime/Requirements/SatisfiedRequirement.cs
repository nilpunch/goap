namespace GOAP
{
    public class SatisfiedRequirement<TState> : IRequirement<TState>
    {
        public int MismatchCost(TState state)
        {
            return 0;
        }
    }
}