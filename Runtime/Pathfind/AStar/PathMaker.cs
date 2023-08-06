using System.Collections.Generic;

namespace GOAP.GoapPathfind.AStar
{
    internal sealed class PathMaker
    {
        private readonly Dictionary<INode, IEdge> _cameFrom;

        public PathMaker()
        {
            _cameFrom = new Dictionary<INode, IEdge>();
        }

        public void AttachNode(INode node, IEdge from)
            => _cameFrom[node] = from;

        public Path ConstructPathFrom(INode start, int iterations)
        {
            var current = start;
            var edges = new List<IEdge>();

            while (_cameFrom.TryGetValue(current, out var via))
            {
                edges.Add(via);
                current = via.Start;
            }

            edges.Reverse();

            PathCompleteness pathCompleteness = start.DistanceToGoal == Distance.Zero ? PathCompleteness.Complete : PathCompleteness.Incomplete;

            return new Path(pathCompleteness, edges, iterations);
        }

        public void Clear() => _cameFrom.Clear();
    }
}