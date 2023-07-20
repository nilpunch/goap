using System.Linq;
using UnityEngine;

public class Bot : MonoBehaviour
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
        var currentState = new State();
        currentState.Set(Hungry, true);
        currentState.Set(HasPhoneNumber, true);
        currentState.Set(HasIngredients, true);
        currentState.Set(HasFood, false);
        currentState.Set(PizzaOrdered, false);
        currentState.Set(FoodMixed, false);
        currentState.Set(FoodCooked, false);
        
        var goal = new State();
        goal.Set(Hungry, false);
    
        var actionsLibrary = new ActionsLibrary();
    
        State eatRequirements = new State();
        eatRequirements.Set(HasFood, true);
        actionsLibrary.Add(new Action(eatRequirements, new BoolSetEffect(Hungry, false), 1, "Eat"));
        
        State phoneForPizzaRequirements = new State();
        phoneForPizzaRequirements.Set(HasPhoneNumber, true);
        actionsLibrary.Add(new Action(phoneForPizzaRequirements, new BoolSetEffect(PizzaOrdered, true), 3, "PhoneForPizza"));
        
        State waitForDeliveryRequirements = new State();
        waitForDeliveryRequirements.Set(PizzaOrdered, true);
        actionsLibrary.Add(new Action(waitForDeliveryRequirements, new BoolSetEffect(HasFood, true), 2, "WaitForDelivery"));
    
        State mixIngredientsRequirements = new State();
        mixIngredientsRequirements.Set(HasIngredients, true);
        actionsLibrary.Add(new Action(mixIngredientsRequirements, new BoolSetEffect(FoodMixed, true), 2, "MixIngredients"));
        
        State cookFoodRequirements = new State();
        cookFoodRequirements.Set(FoodMixed, true);
        actionsLibrary.Add(new Action(cookFoodRequirements, new BoolSetEffect(FoodCooked, true), 3, "CookFood"));
        
        State serveFoodRequirements = new State();
        serveFoodRequirements.Set(FoodCooked, true);
        actionsLibrary.Add(new Action(serveFoodRequirements, new BoolSetEffect(HasFood, true), 1, "ServeFood"));
    
        PathFinder pathFinder = new PathFinder();
        StateComparer stateComparer = new StateComparer();
        Path path = pathFinder.FindPath(new StateNode(currentState, goal, stateComparer, actionsLibrary));
    
        Debug.Log(path.Completeness);
        
        Debug.Log(string.Join(", ", path.Edges.Select(edge => edge.ToString())));
    }
    
    // private void Awake()
    // {
    //     var currentState = new State();
    //     currentState.Set(Hungry, true);
    //     currentState.Set(PizzaOrdered, true);
    //     currentState.Set(HasFood, false);
    //     
    //     var goal = new State();
    //     goal.Set(Hungry, false);
    //
    //     var actionsLibrary = new ActionsLibrary();
    //
    //     State eatRequirements = new State();
    //     eatRequirements.Set(HasFood, true);
    //     actionsLibrary.Add(new Action(eatRequirements, new Effect(new IEffect[]
    //     {
    //         new BoolSetEffect(Hungry, false),
    //     }), 5, "Eat"));
    //
    //     State waitForDeliveryRequirements = new State();
    //     waitForDeliveryRequirements.Set(PizzaOrdered, true);
    //     actionsLibrary.Add(new Action(waitForDeliveryRequirements, new Effect(new IEffect[]
    //     {
    //         new BoolSetEffect(HasFood, true),
    //     }), 2, "WaitForDelivery"));
    //
    //     PathFinder pathFinder = new PathFinder();
    //     Path path = pathFinder.FindPath(new StateNode(currentState, goal, new StateComparer(), actionsLibrary));
    //
    //     Debug.Log(path.Completeness);
    //     
    //     foreach (var edge in path.Edges)
    //     {
    //         Debug.Log(edge);
    //     }
    // }
}