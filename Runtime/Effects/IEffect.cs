using System.Diagnostics.Contracts;

namespace GOAP
{
    public interface IEffect<TState>
    {
        [Pure]
        TState Modify(TState state);
        
        [Pure]
        bool IsChangeSomething(TState state);
    }
}