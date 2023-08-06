using System.Collections.Generic;
using System.Linq;

namespace GOAP
{
    public class ActionsLibrary : IActionsLibrary
    {
        private readonly List<IAction> _actions;

        public IEnumerable<IAction> Actions => _actions;

        public ActionsLibrary()
        {
            _actions = new List<IAction>();
        }
        
        public ActionsLibrary(IEnumerable<IAction> actions)
        {
            _actions = new List<IAction>(actions);
        }
        
        public ActionsLibrary(IEnumerable<IActionsLibrary> actionsLibraries)
        {
            _actions = new List<IAction>(actionsLibraries.SelectMany(library => library.Actions));
        }
        
        public void Add(IAction action)
        {
            _actions.Add(action);
        }
    }
}