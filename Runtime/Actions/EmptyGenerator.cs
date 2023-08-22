using System;
using System.Collections.Generic;

namespace GOAP
{
    public class EmptyGenerator<TState> : IActionGenerator<TState>
    {
        public IEnumerable<IAction<TState>> GenerateActions(TState state) => ArraySegment<IAction<TState>>.Empty;
    }
}