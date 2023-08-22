using System.Linq;
using Common;
using GOAP.AStar;
using UnityEngine;

namespace GOAP
{
    public class MovementTest : MonoBehaviour
    {
        private void OnEnable()
        {
            var worldState = new Blackboard();

            var bot = FindObjectOfType<Bot>();
            worldState.Set(bot.Id, bot.State);

            var interests = FindObjectsOfType<PointOfInterest>();
            var interestsIds = interests.Select(interest => interest.Id).ToArray();
            foreach (var pointOfInterest in interests)
            {
                worldState.Set(pointOfInterest.Id, pointOfInterest.State);
            }

            var goal = new Requirements<IReadOnlyBlackboard>(new IRequirement<IReadOnlyBlackboard>[]
            {
                new BotHaveEnoughCollectedValue(bot.Id, goalValue: 2),
            });
        
            var actionsLibrary = new ActionLibrary<IReadOnlyBlackboard>();
        
            actionsLibrary.AddGenerator(new CollectActionGenerator(bot.Id, interestsIds, 0.25f, 1));
            actionsLibrary.AddGenerator(new BotMovementActionGenerator(bot.Id, interestsIds, 1));

            // Debug.Log("Initial state: " + worldState);
            // Debug.Log("Goal state: " + goal);
            (Path path, int iterations, int outgoingNodes) = new PathFinder().FindPath(new ForwardSearchNode<IReadOnlyBlackboard>(worldState, goal, actionsLibrary));
            Debug.Log("Plan " + path.Completeness + " in " + iterations + " iterations and " + outgoingNodes + " searched actions.");
            Debug.Log("Plan:\n" + string.Join("\n", path.Edges.Select(edge => edge.ToString())));
        }
    }
}