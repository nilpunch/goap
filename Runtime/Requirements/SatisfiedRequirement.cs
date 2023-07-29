public class SatisfiedRequirement : IRequirement
{
    public int MismatchCost(IReadOnlyAssignments assignments)
    {
        return 0;
    }

    public bool IsSatisfied(IReadOnlyAssignments assignments)
    {
        return true;
    }

    public bool IsRuined(IReadOnlyAssignments assignments)
    {
        return false;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyAssignments oldAssignments, IReadOnlyAssignments newAssignments)
    {
        return this;
    }

    public void MakeSatisfactionAssignment(IAssignments assignments)
    {
    }
}