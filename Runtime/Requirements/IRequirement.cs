public interface IRequirement
{
    int MismatchCost(IReadOnlyState state);
    bool IsSatisfied(IReadOnlyState state);
    void SatisfyState(IState state);
    IRequirement GetUnsatisfiedReminder(IReadOnlyState oldState, IReadOnlyState newState);
}