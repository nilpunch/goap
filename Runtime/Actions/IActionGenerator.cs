using System.Collections.Generic;

namespace GOAP
{
    public interface IActionGenerator<TState>
    {
        IEnumerable<IAction<TState>> GenerateActions(TState state);
    }
}