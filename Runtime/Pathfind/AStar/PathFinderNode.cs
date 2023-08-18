using System;

namespace GOAP.AStar
{
    internal sealed class PathFinderNode : IComparable<PathFinderNode>
    {
        public PathFinderNode(INode node, Distance traversedDistance, Distance distanceToGoal)
        {
            Node = node;
            TraversedDistance = traversedDistance;
            DistanceToGoal = distanceToGoal;
            TotalExpectedDistance = traversedDistance + distanceToGoal;
        }


        public INode Node { get; }
        public Distance TraversedDistance { get; }
        public Distance DistanceToGoal { get; }
        public Distance TotalExpectedDistance { get; }

        public int CompareTo(PathFinderNode other) => TotalExpectedDistance.CompareTo(other.TotalExpectedDistance);
        public override string ToString() => $"⏱~{TotalExpectedDistance}";
    }
}