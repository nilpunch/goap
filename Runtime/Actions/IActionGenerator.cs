using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace GOAP
{
    public interface IActionGenerator<TState>
    {
        [Pure]
        IEnumerable<IAction<TState>> GenerateActions(TState state);
    }
}