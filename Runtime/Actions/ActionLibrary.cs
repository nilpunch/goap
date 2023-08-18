using System.Collections.Generic;
using System.Linq;
using Common;

namespace GOAP
{
    public class ActionLibrary : IActionGenerator
    {
        private readonly List<IAction> _staticActions = new List<IAction>();
        private readonly List<IActionGenerator> _actionGenerators = new List<IActionGenerator>();

        public void AddStaticAction(IAction action)
        {
            _staticActions.Add(action);
        }
        
        public void AddGenerator(IActionGenerator actionGenerator)
        {
            _actionGenerators.Add(actionGenerator);
        }

        public IEnumerable<IAction> GenerateActions(IReadOnlyState state)
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