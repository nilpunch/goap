using GOAP.AStar;

namespace GOAP
{
    public sealed class ActionEdge : IEdge
    {
        private readonly string _actionName;

        public ActionEdge(INode start, INode end, Cost length, string actionName = "")
        {
            _actionName = actionName;
            Start = start;
            End = end;
            Cost = length;
        }

        public Cost Cost { get; }

        public INode Start { get; }
        public INode End { get; }

        public override string ToString() => _actionName;
    }
}