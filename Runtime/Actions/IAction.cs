namespace GOAP
{
    public interface IAction<TState>
    {
        IRequirement<TState> Requirement { get; }
        IEffect<TState> Effect { get; }
        int Cost { get; }
    }
}