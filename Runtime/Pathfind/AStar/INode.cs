using System.Collections.Generic;

namespace GOAP.AStar
{
    public interface INode
    {
        Cost Remain { get; }
        IEnumerable<IEdge> Outgoing { get; }
    }
}