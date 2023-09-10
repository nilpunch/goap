using System.Linq;
using GOAP.AStar;
using UnityEngine;

namespace GOAP.Test.Movement
{
    public class MovementTest : MonoBehaviour
    {
        [SerializeField] private int _goalCollectables = 2;
        
        private void OnEnable()
        {
            var interestsBoard = new Board<PropertyId, InterestState>();
            var interests = FindObjectsOfType<PointOfInterest>();
            var interestsIds = interests.Select(interest => interest.Id).ToArray();
            foreach (var pointOfInterest in interests)
            {
                interestsBoard[pointOfInterest.Id] = pointOfInterest.State;
            }
            
            var bot = FindObjectOfType<Bot>();
            var botState = bot.State;

            var worldState = new WorldState(botState, interestsBoard);

            var goal = new Requirements<WorldState>(new IRequirement<WorldState>[]
            {
                new BotHaveEnoughCollectedValue(goalValue: _goalCollectables),
            });
        
            var actionsLibrary = new ActionLibrary<WorldState>();
        
            actionsLibrary.AddGenerator(new CollectActionGenerator(bot.Id, interestsIds, 0.25f, 1));
            actionsLibrary.AddGenerator(new BotMovementActionGenerator(bot.Id, interestsIds, 1));
            
            (Path path, int iterations, int outgoingNodes) = new PathFinder().FindPath(new ForwardSearchNode<WorldState>(worldState, goal, new OnlyRelevantActions<WorldState>(actionsLibrary)));
            Debug.Log("Plan " + path.Completeness + " in " + iterations + " iterations and " + outgoingNodes + " searched actions.");
            Debug.Log("Plan:\n" + string.Join("\n", path.Edges.Select(edge => edge.ToString())));
        }
    }
}