namespace GOAP
{
	public class EmptyEffect<TState> : IEffect<TState>
	{
		public TState Modify(TState state)
		{
			return state;
		}

		public bool IsChangeSomething(TState state)
		{
			return false;
		}
	}
}