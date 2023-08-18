using System.Linq;
using GOAP.AStar;
using Common;
using UnityEngine;

namespace GOAP
{
    public class ComplexBoolTest : MonoBehaviour
    {
        private static PropertyId HasFood { get; } = PropertyId.Unique(nameof(HasFood));
        private static PropertyId Hungry { get; } = PropertyId.Unique(nameof(Hungry));
    
        private static PropertyId HasPhoneNumber { get; } = PropertyId.Unique(nameof(HasPhoneNumber));
        private static PropertyId PizzaOrdered { get; } = PropertyId.Unique(nameof(PizzaOrdered));
    
        private static PropertyId HasIngredients { get; } = PropertyId.Unique(nameof(HasIngredients));
        private static PropertyId FoodMixed { get; } = PropertyId.Unique(nameof(FoodMixed));
        private static PropertyId FoodCooked { get; } = PropertyId.Unique(nameof(FoodCooked));

        private void Awake()
        {
            var worldState = new State();
            worldState.Set(Hungry, true);
            worldState.Set(HasPhoneNumber, true);
            worldState.Set(HasIngredients, true);
            worldState.Set(HasFood, false);
            worldState.Set(PizzaOrdered, false);
            worldState.Set(FoodMixed, false);
            worldState.Set(FoodCooked, false);

            var goal = new Requirements(new IRequirement[]
            {
                new BoolEqualTo(Hungry, false),
                new BoolEqualTo(HasIngredients, true),
            });
    
            var actionsLibrary = new ActionLibrary();
    
            actionsLibrary.AddStaticAction(new Action(new BoolEqualTo(HasFood, true), new Effect(new IEffect[]
            {
                new BoolSetEffect(Hungry, false),
            }), 1, "Eat"));
        
            actionsLibrary.AddStaticAction(new Action(new BoolEqualTo(HasPhoneNumber, true), new BoolSetEffect(PizzaOrdered, true), 2, "PhoneForPizza"));
        
            actionsLibrary.AddStaticAction(new Action(new BoolEqualTo(PizzaOrdered, true), new Effect(new IEffect[]
            {
                new BoolSetEffect(HasFood, true),
                new BoolSetEffect(PizzaOrdered, false),
            }), 7, "WaitForDelivery"));
    
            actionsLibrary.AddStaticAction(new Action(new BoolEqualTo(HasIngredients, true), new Effect(new IEffect[]
            {
                new BoolSetEffect(FoodMixed, true),
                new BoolSetEffect(HasIngredients, false),
            }), 2, "MixIngredients"));
        
            actionsLibrary.AddStaticAction(new Action(new BoolEqualTo(FoodMixed, true), new Effect(new IEffect[]
            {
                new BoolSetEffect(FoodMixed, false),
                new BoolSetEffect(FoodCooked, true),
            }), 3, "CookFood"));
        
            actionsLibrary.AddStaticAction(new Action(new BoolEqualTo(FoodCooked, true), new Effect(new IEffect[]
            {
                new BoolSetEffect(FoodCooked, false),
                new BoolSetEffect(HasFood, true),
            }), 1, "ServeFood"));
        
            actionsLibrary.AddStaticAction(new Action(new SatisfiedRequirement(),
                new BoolSetEffect(HasIngredients, true), 3, "GoToShop"));

            Debug.Log("Initial state: " + worldState);
            Debug.Log("Goal state: " + goal);
            Path path = new PathFinder().FindPath(new ForwardSearchNode(worldState, goal, actionsLibrary));
            Debug.Log("Plan " + path.Completeness + " in " + path.Iterations);
            if (path.Completeness == PathCompleteness.Complete)
                Debug.Log(string.Join(", ", path.Edges.Select(edge => edge.ToString())));
        }
    }
}