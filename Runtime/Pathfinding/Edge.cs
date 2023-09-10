using GOAP.Pathfinding;

namespace GOAP.Pathfinding
{
    public sealed class Edge : IEdge
    {
        private readonly string _name;

        public Edge(INode start, INode end, Cost length, string name = "")
        {
            _name = name;
            Start = start;
            End = end;
            Cost = length;
        }

        public Cost Cost { get; }

        public INode Start { get; }
        public INode End { get; }

        public override string ToString() => _name;
    }
}