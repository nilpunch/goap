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
            var worldState = new State();
            worldState.Set(FoodSupply, 0);
            worldState.Set(HungryLevel, 10);

            var goal = new Requirements(new IRequirement[]
            {
                new IntLessEqualThan(HungryLevel, 0)
            });
    
            var actionsLibrary = new ActionLibrary();
    
            actionsLibrary.AddStaticAction(new Action(new IntGreaterThan(FoodSupply, 0), new Effect(new IEffect[]
            {
                new IntDeltaEffect(FoodSupply, -1),
                new IntDeltaEffect(HungryLevel, -3),
            }) , 1, "EatFood"));
        
            actionsLibrary.AddStaticAction(new Action(new SatisfiedRequirement(), new IntDeltaEffect(FoodSupply, 1), 1, "ObtainFood"));

            Path path = new PathFinder().FindPath(new ForwardSearchNode(worldState, goal, actionsLibrary));
            Debug.Log("Plan " + path.Completeness + " in " + path.Iterations);
            if (path.Completeness == PathCompleteness.Complete)
                Debug.Log(string.Join(", ", path.Edges.Select(edge => edge.ToString())));
        }
    }
}