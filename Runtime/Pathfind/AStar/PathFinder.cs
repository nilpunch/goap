using System.Collections.Generic;

namespace GOAP.AStar
{
    public sealed class PathFinder
    {
        private readonly int _maxIterations;
        private readonly MinHeap<PathFinderNode> _interesting;
        private readonly Dictionary<INode, PathFinderNode> _nodes;
        private readonly PathMaker _pathMaker;

        private PathFinderNode _nodeClosestToGoal;

        public PathFinder(int maxIterations = 10000)
        {
            _maxIterations = maxIterations;
            _interesting = new MinHeap<PathFinderNode>();
            _nodes = new Dictionary<INode, PathFinderNode>();
            _pathMaker = new PathMaker();
        }

        public (Path path, int iterations, int outgoingNodes) FindPath(INode start)
        {
            ResetState();
            AddFirstNode(start);

            int iterations = 0;
            int outgoingNodes = 0;

            while (_interesting.Count > 0 && iterations < _maxIterations)
            {
                iterations++;
                var current = _interesting.Extract();
                if (GoalReached(current))
                {
                    return (_pathMaker.ConstructPathFrom(current.Node), iterations, outgoingNodes);
                }

                UpdateNodeClosestToGoal(current);
            
                foreach (var edge in current.Node.Outgoing)
                {
                    outgoingNodes++;
                    var nextNode = edge.End;
                    var traversingCost = current.Traversed + edge.Cost;

                    if (_nodes.TryGetValue(nextNode, out var node))
                    {
                        UpdateExistingNode(nextNode, edge, traversingCost, node);
                    }
                    else
                    {
                        InsertNode(nextNode, edge, traversingCost);
                    }
                }
            }
        
            return (_pathMaker.ConstructPathFrom(_nodeClosestToGoal.Node), iterations, outgoingNodes);
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
            var head = new PathFinderNode(start, Cost.Zero, start.Remain);
            _interesting.Insert(head);
            _nodes.Add(head.Node, head);
            _nodeClosestToGoal = head;
        }

        private void UpdateNodeClosestToGoal(PathFinderNode current)
        {
            if (current.Remain < _nodeClosestToGoal.Remain)
            {
                _nodeClosestToGoal = current;
            }
        }

        private void UpdateExistingNode(INode node, IEdge from, Cost traversed, PathFinderNode pathfinderNode)
        {
            if (pathfinderNode.Traversed > traversed)
            {
                _interesting.Remove(pathfinderNode);
                InsertNode(node, from, traversed);
            }
        }

        private void InsertNode(INode node, IEdge from, Cost traversed)
        {
            _pathMaker.AttachNode(node, from);

            var pathFinderNode = new PathFinderNode(node, traversed, node.Remain);
            _interesting.Insert(pathFinderNode);
            _nodes[node] = pathFinderNode;
        }

        private static bool GoalReached(PathFinderNode current) => current.Remain == Cost.Zero;
    }
}