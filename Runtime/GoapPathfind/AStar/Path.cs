using System.Collections.Generic;

public sealed class Path
{
    public Path(PathCompleteness completeness, IReadOnlyList<IEdge> edges)
    {
        Completeness = completeness;
        Edges = edges;

        for (var i = 0; i < Edges.Count; i++)
        {
            Distance += Edges[i].Length;
        }
    }

    public PathCompleteness Completeness { get; }

    public Distance Distance { get; }

    public IReadOnlyList<IEdge> Edges { get; }
}