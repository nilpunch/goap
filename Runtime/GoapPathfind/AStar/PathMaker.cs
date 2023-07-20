using System;
using System.Collections.Generic;

internal sealed class PathMaker
{
    private readonly Dictionary<INode, IEdge> _cameFrom;

    public PathMaker()
    {
        _cameFrom = new Dictionary<INode, IEdge>();
    }

    public void AttachNode(INode node, IEdge from)
        => _cameFrom[node] = from;

    public Path ConstructPathFrom(INode start)
    {
        if (start.DistanceToGoal != Distance.Zero)
        {
            return new Path(PathCompleteness.Incomplete, ArraySegment<IEdge>.Empty);
        }

        var current = start;
        var edges = new List<IEdge>();

        while (_cameFrom.TryGetValue(current, out var via))
        {
            edges.Add(via);
            current = via.Start;
        }

        edges.Reverse();

        return new Path(PathCompleteness.Complete, edges);
    }

    public void Clear() => _cameFrom.Clear();
}