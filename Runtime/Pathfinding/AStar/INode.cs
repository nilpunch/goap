using System.Collections.Generic;

namespace GOAP.Pathfinding
{
    public interface INode
    {
        Cost Remain { get; }
        IEnumerable<IEdge> Outgoing { get; }
    }
}