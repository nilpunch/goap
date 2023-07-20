public sealed class ActionEdge : IEdge
{
    private readonly string _actionName;

    public ActionEdge(INode start, INode end, Distance length, string actionName = "")
    {
        _actionName = actionName;
        Start = start;
        End = end;
        Length = length;
    }

    public Distance Length { get; }

    public INode Start { get; }
    public INode End { get; }

    public override string ToString() => _actionName;
}