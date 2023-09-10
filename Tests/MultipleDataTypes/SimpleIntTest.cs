using System.Linq;
using GOAP.Pathfinding;
using UnityEngine;

namespace GOAP.Test.MultiData
{
    public class SimpleIntTest : MonoBehaviour
    {
        private static PropertyId HaveFood { get; } = PropertyId.Unique();
        private static PropertyId HungryLevel { get; } = PropertyId.Unique();

        private void Awake()
        {
            IWriteBoard<PropertyId, bool> boolBoard = new Board<PropertyId, bool>();
            IWriteBoard<PropertyId, int> intBoard = new Board<PropertyId, int>();
            boolBoard[HaveFood] = false;
            intBoard[HungryLevel] = 10;
            
            var worldState = new WorldState(boolBoard, intBoard);

            var goal = new Requirements<WorldState>(new IRequirement<WorldState>[]
            {
                new WorldStateIntRequirement(new IntLessEqualThan<PropertyId>(HungryLevel, 0)),
            });
    
            var actionsLibrary = new ActionLibrary<WorldState>();
    
            actionsLibrary.AddAction(new Action<WorldState>(new WorldStateBoolRequirement(new BoolEqualTo<PropertyId>(HaveFood, true)), new Effect<WorldState>(new IEffect<WorldState>[]
            {
                new WorldStateBoolEffect(new BoolSetEffect<PropertyId>(HaveFood, false)),
                new WorldStateIntEffect(new IntDeltaEffect<PropertyId>(HungryLevel, -3)),
            }) , 1, "EatFood"));
        
            actionsLibrary.AddAction(new Action<WorldState>(new SatisfiedRequirement<WorldState>(),
                new WorldStateBoolEffect(new BoolSetEffect<PropertyId>(HaveFood, true)),
                1, "ObtainFood"));

            (var path, var iterations, var outgoingNodes) = new Pathfinding.AStar().FindPath(new ForwardSearchNode<WorldState>(worldState, goal, new OnlyRelevantActions<WorldState>(actionsLibrary)));
            Debug.Log("Plan " + path.Completeness + " in " + iterations + " iterations and " + outgoingNodes + " searched actions.");
            Debug.Log("Plan:\n" + string.Join("\n", path.Edges.Select(edge => edge.ToString())));
        }
    }
}