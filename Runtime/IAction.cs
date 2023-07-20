public interface IAction
{
    IReadOnlyState Requirements { get; }
    IEffect Effect { get; }
    public float Cost { get; }
}