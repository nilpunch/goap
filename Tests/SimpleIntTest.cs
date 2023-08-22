using System.Linq;
using GOAP.AStar;
using Common;
using UnityEngine;

namespace GOAP
{
    public class SimpleIntTest : MonoBehaviour
    {
        private static PropertyId FoodSupply { get; } = PropertyId.Unique(nameof(FoodSupply));
        private static PropertyId HungryLevel { get; } = PropertyId.Unique(nameof(HungryLevel));

        private void Awake()
        {
            var worldState = new Blackboard();
            worldState.Set(FoodSupply, 0);
            worldState.Set(HungryLevel, 10);

            var goal = new Requirements<IReadOnlyBlackboard>(new IRequirement<IReadOnlyBlackboard>[]
            {
                new IntLessEqualThan(HungryLevel, 0)
            });
    
            var actionsLibrary = new ActionLibrary<IReadOnlyBlackboard>();
    
            actionsLibrary.AddAction(new Action<IReadOnlyBlackboard>(new IntGreaterThan(FoodSupply, 0), new Effect<IReadOnlyBlackboard>(new IEffect<IReadOnlyBlackboard>[]
            {
                new IntDeltaEffect(FoodSupply, -1),
                new IntDeltaEffect(HungryLevel, -3),
            }) , 1, "EatFood"));
        
            actionsLibrary.AddAction(new Action<IReadOnlyBlackboard>(new SatisfiedRequirement<IReadOnlyBlackboard>(), new IntDeltaEffect(FoodSupply, 1), 1, "ObtainFood"));

            (Path path, int iterations, int outgoingNodes) = new PathFinder().FindPath(new ForwardSearchNode<IReadOnlyBlackboard>(worldState, goal, actionsLibrary));
            Debug.Log("Plan " + path.Completeness + " in " + iterations + " iterations and " + outgoingNodes + " searched actions.");
            Debug.Log("Plan:\n" + string.Join("\n", path.Edges.Select(edge => edge.ToString())));
        }
    }
}