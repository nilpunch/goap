namespace GOAP.GoapPathfind.AStar
{
    public interface IEdge
    {
        Distance Length { get; }
        INode Start { get; }
        INode End { get; }
    }
}