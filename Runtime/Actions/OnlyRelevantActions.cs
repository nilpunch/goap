using System.Collections.Generic;

namespace GOAP
{
	public class OnlyRelevantActions<TState> : IActionGenerator<TState>
	{
		private readonly IActionGenerator<TState> _actionGenerator;

		public OnlyRelevantActions(IActionGenerator<TState> actionGenerator)
		{
			_actionGenerator = actionGenerator;
		}
        
		public IEnumerable<IAction<TState>> GenerateActions(TState state)
		{
			foreach (var action in _actionGenerator.GenerateActions(state))
			{
				if (action.Requirement.IsSatisfied(state) && action.Effect.IsChangeSomething(state))
					yield return action;
			}
		}
	}
}