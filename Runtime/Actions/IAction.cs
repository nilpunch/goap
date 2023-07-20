public interface IAction
{
    IReadOnlyState Requirement { get; }
    IEffect Effect { get; }
    public float Cost { get; }
}