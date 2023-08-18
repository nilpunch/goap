using System.Collections.Generic;

namespace GOAP.AStar
{
    public interface INode
    {
        Distance DistanceToGoal { get; }
        IEnumerable<IEdge> Outgoing { get; }
    }
}