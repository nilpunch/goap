using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    public class ActionLibrary<TState> : IActionGenerator<TState>
    {
        private readonly List<IAction<TState>> _staticActions = new List<IAction<TState>>();
        private readonly List<IActionGenerator<TState>> _actionGenerators = new List<IActionGenerator<TState>>();

        public void AddAction(IAction<TState> action)
        {
            _staticActions.Add(action);
        }
        
        public void AddGenerator(IActionGenerator<TState> actionGenerator)
        {
            _actionGenerators.Add(actionGenerator);
        }

        public IEnumerable<IAction<TState>> GenerateActions(TState state)
        {
            foreach (var staticAction in _staticActions)
            {
                yield return staticAction;
            }

            foreach (var action in _actionGenerators.SelectMany(actionGenerator => actionGenerator.GenerateActions(state)))
            {
                yield return action;
            }
        }
    }
}