using System.Linq;
using Common;
using GOAP.AStar;
using UnityEngine;

namespace GOAP
{
    public class MovementTest : MonoBehaviour
    {
        private static PropertyId Bot { get; } = PropertyId.Unique(nameof(Bot));
        
        private static PropertyId Chest { get; } = PropertyId.Unique(nameof(Chest));
        private static PropertyId Tree { get; } = PropertyId.Unique(nameof(Tree));
        private static PropertyId Bridge { get; } = PropertyId.Unique(nameof(Bridge));
        private static PropertyId Castle { get; } = PropertyId.Unique(nameof(Castle));

        private static PropertyId[] Interesets { get; } = new[]
        {
            Chest,
            Tree,
            Bridge,
            Castle,
        };

        private void Awake()
        {
            var worldState = new State();
            worldState.Set(Bot, new BotState(Vector3.zero, 3f, 0));
            
            worldState.Set(Tree, new InterestState(Vector3.right * 1f, 0));
            worldState.Set(Chest, new InterestState(Vector3.right * 3.5f, 5));
            worldState.Set(Bridge, new InterestState(Vector3.forward * 2f, 0));
            worldState.Set(Castle, new InterestState(Vector3.forward * 4f, 5));
            
            // Map:
            // _________________________________
            // ________Castle___________________
            // _________________________________
            // ________Bridge___________________
            // _________________________________
            // ________Bot___Tree_______Chest___
            // _________________________________

            var goal = new Requirements(new IRequirement[]
            {
                new BotHaveEnoughCollectedValue(Bot, 7),
                new IsBotInRangeOfInterest(Bot, Chest, 0.25f, 1)
            });
        
            var actionsLibrary = new ActionLibrary();
        
            actionsLibrary.AddGenerator(new CollectActionGenerator(Bot, Interesets, 0.25f, 1));
            actionsLibrary.AddGenerator(new BotMovementActionGenerator(Bot, Interesets, 1));

            // Debug.Log("Initial state: " + worldState);
            // Debug.Log("Goal state: " + goal);
            Path path = new PathFinder().FindPath(new ForwardSearchNode(worldState, goal, actionsLibrary));
            Debug.Log("Plan " + path.Completeness + " in " + path.Iterations + " iterations and " + ForwardSearchNode.NodesOutgo + " searched actions.");
            if (path.Completeness == PathCompleteness.Complete)
                Debug.Log("Plan: " + string.Join(", ", path.Edges.Select(edge => edge.ToString())));
        }
    }
}