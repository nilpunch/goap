using System;
using System.Collections.Generic;
using Common;

namespace GOAP
{
    public class EmptyGenerator : IActionGenerator
    {
        public IEnumerable<IAction> GenerateActions(IReadOnlyState state) => ArraySegment<IAction>.Empty;
    }
}