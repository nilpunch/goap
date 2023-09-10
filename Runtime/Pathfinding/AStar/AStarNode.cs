using System;

namespace GOAP.Pathfinding
{
    internal sealed class AStarNode : IComparable<AStarNode>
    {
        public AStarNode(INode node, Cost traversed, Cost remain)
        {
            Node = node;
            Traversed = traversed;
            Remain = remain;
            TotalExpectedCost = traversed + remain;
        }

        public INode Node { get; }
        public Cost Traversed { get; }
        public Cost Remain { get; }
        private Cost TotalExpectedCost { get; }

        public int CompareTo(AStarNode other)
        {
            return TotalExpectedCost.CompareTo(other.TotalExpectedCost);
        }

        public override string ToString() => $"⏱~{TotalExpectedCost}";
    }
}