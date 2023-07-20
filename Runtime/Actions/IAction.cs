public interface IAction
{
    IReadOnlyState Requirement { get; }
    IEffect Effect { get; }
    public int Cost { get; }
}