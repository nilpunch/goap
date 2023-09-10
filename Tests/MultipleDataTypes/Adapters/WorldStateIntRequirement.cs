namespace GOAP.Test.MultiData
{
	public class WorldStateIntRequirement : IRequirement<WorldState>
	{
		private readonly IRequirement<IBoard<PropertyId, int>> _intRequirement;

		public WorldStateIntRequirement(IRequirement<IBoard<PropertyId, int>> intRequirement)
		{
			_intRequirement = intRequirement;
		}
        
		public int MismatchCost(WorldState state)
		{
			return _intRequirement.MismatchCost(state.IntBoard);
		}
	}
}