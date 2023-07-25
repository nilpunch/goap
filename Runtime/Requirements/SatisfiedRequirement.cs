public class SatisfiedRequirement : IRequirement
{
    public int MismatchCost(IReadOnlyState state)
    {
        return 0;
    }

    public bool IsSatisfied(IReadOnlyState state)
    {
        return true;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyState oldState, IReadOnlyState newState)
    {
        return this;
    }

    public void SatisfyState(IState state)
    {
    }
}