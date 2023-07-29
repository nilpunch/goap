public interface IRequirement
{
    int MismatchCost(IReadOnlyAssignments assignments);
    bool IsSatisfied(IReadOnlyAssignments assignments);

    bool IsRuined(IReadOnlyAssignments assignments);
    
    void MakeSatisfactionAssignment(IAssignments assignments);
    IRequirement GetUnsatisfiedReminder(IReadOnlyAssignments oldAssignments, IReadOnlyAssignments newAssignments);
}