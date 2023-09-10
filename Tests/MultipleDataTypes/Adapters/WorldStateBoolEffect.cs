namespace GOAP.Test.MultiData
{
	public class WorldStateBoolEffect : IEffect<WorldState>
	{
		private readonly IEffect<IBoard<PropertyId, bool>> _boolEffect;

		public WorldStateBoolEffect(IEffect<IBoard<PropertyId, bool>> boolEffect)
		{
			_boolEffect = boolEffect;
		}
		
		public WorldState Modify(WorldState state)
		{
			var newBoolState = _boolEffect.Modify(state.BoolBoard);

			return new WorldState(newBoolState, state.IntBoard);
		}

		public bool IsChangeSomething(WorldState state)
		{
			return _boolEffect.IsChangeSomething(state.BoolBoard);
		}
	}
}