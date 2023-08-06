using System;
using System.Collections.Generic;

namespace GOAP
{
    public class EmptyActions : IActionsLibrary
    {
        public IEnumerable<IAction> Actions => ArraySegment<IAction>.Empty;
    }
}