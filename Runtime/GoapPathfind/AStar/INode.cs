using System.Collections.Generic;

public interface INode
{
    Distance DistanceToGoal { get; }
    IEnumerable<IEdge> Outgoing { get; }
}