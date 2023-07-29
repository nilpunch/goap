﻿using System.Linq;
using UnityEngine;

public class SimpleIntTest : MonoBehaviour
{
    [SerializeField] private bool _goInReverse = false;
    
    private static PropertyId FoodSupply { get; } = PropertyId.Unique(nameof(FoodSupply));
    private static PropertyId HungryLevel { get; } = PropertyId.Unique(nameof(HungryLevel));

    private void Awake()
    {
        var worldState = new Assignments();
        worldState.Set(FoodSupply, 0);
        worldState.Set(HungryLevel, 10);

        var goal = new Requirements(new IRequirement[]
        {
            new IntLessEqualRequirement(HungryLevel, 0, 1, 100)
        });
    
        var actionsLibrary = new ActionsLibrary();
    
        actionsLibrary.Add(new Action(new IntGreaterEqualRequirement(FoodSupply, 1, 1, 0), new Effect(new IEffect[]
        {
            new IntDeltaEffect(FoodSupply, -1),
            new IntDeltaEffect(HungryLevel, -3),
        }) , 1, "EatFood"));
        
        actionsLibrary.Add(new Action(new SatisfiedRequirement(), new IntDeltaEffect(FoodSupply, 1), 1, "ObtainFood"));

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