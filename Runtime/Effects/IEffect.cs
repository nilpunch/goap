public interface IEffect
{
    void Modify(IState state);
    bool IsChangeSomething(IReadOnlySate state);
}