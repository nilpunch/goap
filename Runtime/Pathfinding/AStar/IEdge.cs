namespace GOAP.Pathfinding
{
    public interface IEdge
    {
        Cost Cost { get; }
        INode Start { get; }
        INode End { get; }
    }
}