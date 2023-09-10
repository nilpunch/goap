using System.Diagnostics;
using System.Linq;
using GOAP.Pathfinding;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GOAP.Test.Movement
{
    public class MovementTest : MonoBehaviour
    {
        [SerializeField] private int _goalCollectables = 2;
        
        private PointOfInterest[] _interests;
        private Bot _bot;
        private AStar _aStar;

        private void Awake()
        {
            _bot = FindObjectOfType<Bot>();
            _interests = FindObjectsOfType<PointOfInterest>();
            _aStar = new AStar();
        }

        private void Update()
        {
            var interestsBoard = new Board<PropertyId, InterestState>();
            var interestsIds = _interests.Select(interest => interest.Id).ToArray();
            foreach (var pointOfInterest in _interests)
            {
                interestsBoard[pointOfInterest.Id] = pointOfInterest.State;
            }

            var botState = _bot.State;

            var worldState = new WorldState(botState, interestsBoard);

            var goal = new Requirements<WorldState>(new IRequirement<WorldState>[]
            {
                new BotHaveEnoughCollectedValue(goalValue: _goalCollectables),
            });
        
            var actionsLibrary = new ActionLibrary<WorldState>();
        
            actionsLibrary.AddGenerator(new CollectActionGenerator(interestsIds, 0.25f, 1));
            actionsLibrary.AddGenerator(new BotMovementActionGenerator(interestsIds, 1));

            (var path, var iterations, var outgoingNodes) = _aStar.FindPath(new ForwardSearchNode<WorldState>(worldState, goal, new OnlyRelevantActions<WorldState>(actionsLibrary)));
            // Debug.Log("Plan " + path.Completeness + " in " + iterations + " iterations and " + outgoingNodes + " searched actions.");
            // Debug.Log("Plan:\n" + string.Join("\n", path.Edges.Select(edge => edge.ToString())));
        }
    }
}