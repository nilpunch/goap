using System;

namespace GOAP.AStar
{
    internal sealed class PathFinderNode : IComparable<PathFinderNode>
    {
        public PathFinderNode(INode node, Cost traversed, Cost remain)
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

        public int CompareTo(PathFinderNode other)
        {
            return TotalExpectedCost.CompareTo(other.TotalExpectedCost);
        }

        public override string ToString() => $"⏱~{TotalExpectedCost}";
    }
}