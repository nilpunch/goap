using System.Collections.Generic;

namespace GOAP.GoapPathfind.AStar
{
    public interface INode
    {
        Distance DistanceToGoal { get; }
        IEnumerable<IEdge> Outgoing { get; }
    }
}