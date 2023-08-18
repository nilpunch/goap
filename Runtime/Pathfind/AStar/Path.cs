using System.Collections.Generic;

namespace GOAP.AStar
{
    public sealed class Path
    {
        public Path(PathCompleteness completeness, IReadOnlyList<IEdge> edges, int iterations)
        {
            Completeness = completeness;
            Edges = edges;
            Iterations = iterations;

            for (var i = 0; i < Edges.Count; i++)
            {
                Distance += Edges[i].Length;
            }
        }

        public PathCompleteness Completeness { get; }

        public Distance Distance { get; }

        public IReadOnlyList<IEdge> Edges { get; }
        public int Iterations { get; }
    }
}