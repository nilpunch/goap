using System.Collections.Generic;
using System.Linq;

namespace GOAP.Pathfinding
{
    public sealed class Path
    {
        public Path(PathCompleteness completeness, IReadOnlyList<IEdge> edges)
        {
            Completeness = completeness;
            Edges = edges;
        }

        public PathCompleteness Completeness { get; }

        public IReadOnlyList<IEdge> Edges { get; }
        
        public Cost Cost => new Cost(Edges.Sum(edge => edge.Cost.Value));
    }
}