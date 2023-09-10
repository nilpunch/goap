using System.Linq;
using GOAP.Pathfinding;
using UnityEngine;

namespace GOAP
{
    public class ComplexBoolTest : MonoBehaviour
    {
        private static PropertyId HasFood { get; } = PropertyId.Unique();
        private static PropertyId Hungry { get; } = PropertyId.Unique();
    
        private static PropertyId HasPhoneNumber { get; } = PropertyId.Unique();
        private static PropertyId PizzaOrdered { get; } = PropertyId.Unique();
    
        private static PropertyId HasIngredients { get; } = PropertyId.Unique();
        private static PropertyId FoodMixed { get; } = PropertyId.Unique();
        private static PropertyId FoodCooked { get; } = PropertyId.Unique();

        private void Awake()
        {
            var worldState = new Board<PropertyId, bool>();
            worldState[Hungry] = true;
            worldState[HasPhoneNumber] = true;
            worldState[HasIngredients] = true;
            worldState[HasFood] = false;
            worldState[PizzaOrdered] = false;
            worldState[FoodMixed] = false;
            worldState[FoodCooked] = false;

            var goal = new Requirements<IBoard<PropertyId, bool>>(new IRequirement<IBoard<PropertyId, bool>>[]
            {
                new BoolEqualTo<PropertyId>(Hungry, false),
                new BoolEqualTo<PropertyId>(HasIngredients, true),
            });
    
            var actionsLibrary = new ActionLibrary<IBoard<PropertyId, bool>>();
    
            actionsLibrary.AddAction(new Action<IBoard<PropertyId, bool>>(new BoolEqualTo<PropertyId>(HasFood, true), new Effect<IBoard<PropertyId, bool>>(new IEffect<IBoard<PropertyId, bool>>[]
            {
                new BoolSetEffect<PropertyId>(Hungry, false),
            }), 1, "Eat"));
        
            actionsLibrary.AddAction(new Action<IBoard<PropertyId, bool>>(new BoolEqualTo<PropertyId>(HasPhoneNumber, true), new BoolSetEffect<PropertyId>(PizzaOrdered, true), 2, "PhoneForPizza"));
        
            actionsLibrary.AddAction(new Action<IBoard<PropertyId, bool>>(new BoolEqualTo<PropertyId>(PizzaOrdered, true), new Effect<IBoard<PropertyId, bool>>(new IEffect<IBoard<PropertyId, bool>>[]
            {
                new BoolSetEffect<PropertyId>(HasFood, true),
                new BoolSetEffect<PropertyId>(PizzaOrdered, false),
            }), 7, "WaitForDelivery"));
    
            actionsLibrary.AddAction(new Action<IBoard<PropertyId, bool>>(new BoolEqualTo<PropertyId>(HasIngredients, true), new Effect<IBoard<PropertyId, bool>>(new IEffect<IBoard<PropertyId, bool>>[]
            {
                new BoolSetEffect<PropertyId>(FoodMixed, true),
                new BoolSetEffect<PropertyId>(HasIngredients, false),
            }), 2, "MixIngredients"));
        
            actionsLibrary.AddAction(new Action<IBoard<PropertyId, bool>>(new BoolEqualTo<PropertyId>(FoodMixed, true), new Effect<IBoard<PropertyId, bool>>(new IEffect<IBoard<PropertyId, bool>>[]
            {
                new BoolSetEffect<PropertyId>(FoodMixed, false),
                new BoolSetEffect<PropertyId>(FoodCooked, true),
            }), 3, "CookFood"));
        
            actionsLibrary.AddAction(new Action<IBoard<PropertyId, bool>>(new BoolEqualTo<PropertyId>(FoodCooked, true), new Effect<IBoard<PropertyId, bool>>(new IEffect<IBoard<PropertyId, bool>>[]
            {
                new BoolSetEffect<PropertyId>(FoodCooked, false),
                new BoolSetEffect<PropertyId>(HasFood, true),
            }), 1, "ServeFood"));
        
            actionsLibrary.AddAction(new Action<IBoard<PropertyId, bool>>(new SatisfiedRequirement<IBoard<PropertyId, bool>>(),
                new BoolSetEffect<PropertyId>(HasIngredients, true), 3, "GoToShop"));

            (var path, var iterations, var outgoingNodes) = new Pathfinding.AStar().FindPath(new ForwardSearchNode<IBoard<PropertyId, bool>>(worldState, goal, new OnlyRelevantActions<IBoard<PropertyId, bool>>(actionsLibrary)));
            Debug.Log("Plan " + path.Completeness + " in " + iterations + " iterations and " + outgoingNodes + " searched actions.");
            if (path.Completeness == PathCompleteness.Complete)
                Debug.Log("Plan:\n" + string.Join("\n", path.Edges.Select(edge => edge.ToString())));
        }
    }
}