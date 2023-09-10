using System.Collections.Generic;

namespace GOAP.Pathfinding
{
    public sealed class AStar
    {
        private readonly int _maxIterations;
        private readonly MinHeap<AStarNode> _interesting;
        private readonly Dictionary<INode, AStarNode> _nodes;
        private readonly PathMaker _pathMaker;

        private AStarNode _nodeClosestToGoal;

        public AStar(int maxIterations = 10000)
        {
            _maxIterations = maxIterations;
            _interesting = new MinHeap<AStarNode>();
            _nodes = new Dictionary<INode, AStarNode>();
            _pathMaker = new PathMaker();
        }

        public (Path path, int iterations, int outgoingNodes) FindPath(INode start)
        {
            ResetState();
            AddFirstNode(start);

            var iterations = 0;
            var outgoingNodes = 0;

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
            var head = new AStarNode(start, Cost.Zero, start.Remain);
            _interesting.Insert(head);
            _nodes.Add(head.Node, head);
            _nodeClosestToGoal = head;
        }

        private void UpdateNodeClosestToGoal(AStarNode current)
        {
            if (current.Remain < _nodeClosestToGoal.Remain)
            {
                _nodeClosestToGoal = current;
            }
        }

        private void UpdateExistingNode(INode node, IEdge from, Cost traversed, AStarNode pathfinderNode)
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

            var pathFinderNode = new AStarNode(node, traversed, node.Remain);
            _interesting.Insert(pathFinderNode);
            _nodes[node] = pathFinderNode;
        }

        private static bool GoalReached(AStarNode current) => current.Remain == Cost.Zero;
    }
}