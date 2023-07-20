﻿using System.Collections.Generic;

public sealed class PathFinder
{
    private readonly MinHeap<PathFinderNode> _interesting;
    private readonly Dictionary<INode, PathFinderNode> _nodes;
    private readonly PathMaker _pathMaker;

    private PathFinderNode _nodeClosestToGoal;

    public PathFinder()
    {
        _interesting = new MinHeap<PathFinderNode>();
        _nodes = new Dictionary<INode, PathFinderNode>();
        _pathMaker = new PathMaker();
    }

    public Path FindPath(INode start, INode goal)
    {
        ResetState();
        AddFirstNode(start);

        while (_interesting.Count > 0)
        {
            var current = _interesting.Extract();
            if (GoalReached(goal, current))
            {
                return _pathMaker.ConstructPathTo(current.Node, goal);
            }

            UpdateNodeClosestToGoal(current);

            foreach (var edge in current.Node.Outgoing)
            {
                var nextNode = edge.End;
                var distanceToNext = current.TraversedDistance + edge.Length;

                if (_nodes.TryGetValue(nextNode, out var node))
                {
                    UpdateExistingNode(edge, nextNode, distanceToNext, node);
                }
                else
                {
                    InsertNode(nextNode, edge, distanceToNext);
                }
            }
        }

        return _pathMaker.ConstructPathTo(_nodeClosestToGoal.Node, goal);
    }

    private void ResetState()
    {
        _interesting.Clear();
        _nodes.Clear();
        _pathMaker.Clear();
        _nodeClosestToGoal = null;
    }

    private void AddFirstNode(INode start)
    {
        var head = new PathFinderNode(start, Distance.Zero, start.DistanceToGoal);
        _interesting.Insert(head);
        _nodes.Add(head.Node, head);
        _nodeClosestToGoal = head;
    }

    private void UpdateNodeClosestToGoal(PathFinderNode current)
    {
        if (current.DistanceToGoal < _nodeClosestToGoal.DistanceToGoal)
        {
            _nodeClosestToGoal = current;
        }
    }

    private void UpdateExistingNode(IEdge edge, INode oppositeNode, Distance traversedDistance, PathFinderNode node)
    {
        if (node.TraversedDistance > traversedDistance)
        {
            _interesting.Remove(node);
            InsertNode(oppositeNode, edge, traversedDistance);
        }
    }

    private void InsertNode(INode node, IEdge from, Distance traversedDistance)
    {
        _pathMaker.AttachNode(node, from);

        var pathFinderNode = new PathFinderNode(node, traversedDistance, node.DistanceToGoal);
        _interesting.Insert(pathFinderNode);
        _nodes[node] = pathFinderNode;
    }

    private static bool GoalReached(INode goal, PathFinderNode current) => current.Node == goal;
}