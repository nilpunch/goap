namespace GOAP
{
    public interface IEffect<TState>
    {
        TState Modify(TState state);
        bool IsChangeSomething(TState state);
    }
}