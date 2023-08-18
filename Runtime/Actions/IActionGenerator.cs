using System.Collections.Generic;
using Common;

namespace GOAP
{
    public interface IActionGenerator
    {
        IEnumerable<IAction> GenerateActions(IReadOnlyState state);
    }
}