using System.Linq;
using UnityEngine;

public class ComplexBoolTest : MonoBehaviour
{
    [SerializeField] private bool _goInReverse = false;

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
            new BoolRequirement(Hungry, false),
            new BoolRequirement(HasIngredients, true),
        });
    
        var actionsLibrary = new ActionsLibrary();
    
        actionsLibrary.Add(new Action(new BoolRequirement(HasFood, true), new Effect(new IEffect[]
        {
            new BoolSetEffect(Hungry, false),
            new BoolSetEffect(HasFood, false),
        }), 1, "Eat"));
        
        actionsLibrary.Add(new Action(new BoolRequirement(HasPhoneNumber, true),
            new BoolSetEffect(PizzaOrdered, true), 2, "PhoneForPizza"));
        
        actionsLibrary.Add(new Action(new BoolRequirement(PizzaOrdered, true), new Effect(new IEffect[]
        {
            new BoolSetEffect(HasFood, true),
        }), 7, "WaitForDelivery"));
    
        actionsLibrary.Add(new Action(new BoolRequirement(HasIngredients, true), new Effect(new IEffect[]
        {
            new BoolSetEffect(FoodMixed, true),
            new BoolSetEffect(HasIngredients, false),
        }), 2, "MixIngredients"));
        
        actionsLibrary.Add(new Action(new BoolRequirement(FoodMixed, true), new Effect(new IEffect[]
        {
            new BoolSetEffect(FoodCooked, true),
        }), 3, "CookFood"));
        
        actionsLibrary.Add(new Action(new BoolRequirement(FoodCooked, true), new Effect(new IEffect[]
        {
            new BoolSetEffect(HasFood, true),
        }), 1, "ServeFood"));
        
        actionsLibrary.Add(new Action(new BoolRequirement(HasIngredients, false),
            new BoolSetEffect(HasIngredients, true), 3, "GoToShop"));

        if (_goInReverse)
        {
            Path path = new PathFinder().FindPath(new RegressionSearchNode(worldState, goal, actionsLibrary));
            Debug.Log(path.Completeness + " in " + path.Iterations);
            if (path.Completeness == PathCompleteness.Complete)
                Debug.Log(string.Join(", ", path.Edges.Reverse().Select(edge => edge.ToString())));
        }
        else
        {
            Path path = new PathFinder().FindPath(new ForwardSearchNode(worldState, goal, actionsLibrary));
            Debug.Log(path.Completeness + " in " + path.Iterations);
            if (path.Completeness == PathCompleteness.Complete)
                Debug.Log(string.Join(", ", path.Edges.Select(edge => edge.ToString())));
        }
    }
}