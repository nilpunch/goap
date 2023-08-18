namespace GOAP.AStar
{
    public interface IEdge
    {
        Distance Length { get; }
        INode Start { get; }
        INode End { get; }
    }
}