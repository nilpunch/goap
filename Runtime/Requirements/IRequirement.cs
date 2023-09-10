using System.Diagnostics.Contracts;

namespace GOAP
{
    public interface IRequirement<in TState>
    {
        [Pure]
        int MismatchCost(TState state);
        
        [Pure]
        bool IsSatisfied(TState state) => MismatchCost(state) == 0;
    }
}