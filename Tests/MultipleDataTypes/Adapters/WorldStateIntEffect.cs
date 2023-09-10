namespace GOAP.Test.MultiData
{
	public class WorldStateIntEffect : IEffect<WorldState>
	{
		private readonly IEffect<IBoard<PropertyId, int>> _intEffect;

		public WorldStateIntEffect(IEffect<IBoard<PropertyId, int>> intEffect)
		{
			_intEffect = intEffect;
		}
		
		public WorldState Modify(WorldState state)
		{
			var newIntState = _intEffect.Modify(state.IntBoard);

			return new WorldState(state.BoolBoard, newIntState);
		}

		public bool IsChangeSomething(WorldState state)
		{
			return _intEffect.IsChangeSomething(state.IntBoard);
		}
	}
}