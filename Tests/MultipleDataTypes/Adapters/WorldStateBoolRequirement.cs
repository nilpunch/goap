namespace GOAP.Test.MultiData
{
	public class WorldStateBoolRequirement : IRequirement<WorldState>
	{
		private readonly IRequirement<IBoard<PropertyId, bool>> _boolRequirement;

		public WorldStateBoolRequirement(IRequirement<IBoard<PropertyId, bool>> boolRequirement)
		{
			_boolRequirement = boolRequirement;
		}
        
		public int MismatchCost(WorldState state)
		{
			return _boolRequirement.MismatchCost(state.BoolBoard);
		}
	}
}