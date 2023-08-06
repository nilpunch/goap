using System.Linq;
using Common;
using GOAP.Effects;
using GOAP.GoapPathfind;
using GOAP.GoapPathfind.AStar;
using UnityEngine;

namespace GOAP
{
    public class VariableActionsTest : MonoBehaviour
    {
        private static PropertyId RobotLocation { get; } = PropertyId.Unique(nameof(RobotLocation));
        private static PropertyId TableLocation { get; } = PropertyId.Unique(nameof(TableLocation));
        private static PropertyId LampLocation { get; } = PropertyId.Unique(nameof(LampLocation));
        private static PropertyId RobotHaveTable { get; } = PropertyId.Unique(nameof(RobotHaveTable));
        private static PropertyId LampIsFunctioning { get; } = PropertyId.Unique(nameof(LampIsFunctioning));

        private void Awake()
        {
            var worldState = new State();
            worldState.Set(RobotLocation, Location.A);
            worldState.Set(TableLocation, Location.C);
            worldState.Set(LampLocation, Location.B);
            worldState.Set(RobotHaveTable, false);
            worldState.Set(LampIsFunctioning, false);
        
            var goal = new Requirements(new IRequirement[]
            {
                new BoolEqualTo(LampIsFunctioning, true),
            });
        
            var actionsLibrary = new ActionsLibrary();
        
            actionsLibrary.Add(new Action(new Requirements(new IRequirement[]
            {
                new BoolEqualTo(RobotHaveTable, true),
                new InSameLocation(RobotLocation, LampLocation),
            }), new Effect(new IEffect[]
            {
                new BoolSetEffect(LampIsFunctioning, true)
            }) , 1, "Repair Lamp"));
            
            actionsLibrary.Add(new Action(new Requirements(new IRequirement[]
            {
                new InSameLocation(RobotLocation, TableLocation),
            }), new Effect(new IEffect[]
            {
                new BoolSetEffect(RobotHaveTable, true)
            }) , 1, "Obtain table"));
        
            Debug.Log("Initial state: " + worldState);
            Debug.Log("Goal state: " + goal);
            Path path = new PathFinder().FindPath(new ForwardSearchNode(worldState, goal, actionsLibrary));
            Debug.Log("Plan " + path.Completeness + " in " + path.Iterations + " iterations and " + ForwardSearchNode.NodesOutgo + " searched actions.");
            if (path.Completeness == PathCompleteness.Complete)
                Debug.Log("Plan: " + string.Join(", ", path.Edges.Select(edge => edge.ToString())));
        }
    }
}