using UnityEngine;

public class Bot : MonoBehaviour
{
    private void Awake()
    {
        ActionsLibrary actionsLibrary = new ActionsLibrary();

        PathFinder pathFinder = new PathFinder();
        StateComparer stateComparer = new StateComparer();

        IReadOnlyState goal = new State();

        
        
    }
}