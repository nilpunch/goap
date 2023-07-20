public sealed class Edge : IEdge
{
    public Edge(INode start, INode end, Distance length)
    {
        Start = start;
        End = end;
        Length = length;
    }

    public Distance Length { get; }

    public INode Start { get; }
    public INode End { get; }

    public override string ToString() => $"{Start} -> {End}";
}