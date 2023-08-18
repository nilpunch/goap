namespace GOAP
{
    public interface IAction
    {
        IRequirement Requirement { get; }
        IEffect Effect { get; }
        int Cost { get; }
    }
}