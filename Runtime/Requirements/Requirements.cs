using System.Collections.Generic;
using System.Linq;

public class Requirements : IRequirement
{
    private readonly List<IRequirement> _requirements;

    public Requirements()
    {
        _requirements = new List<IRequirement>();
    }
    
    public Requirements(IEnumerable<IRequirement> requirements)
    {
        _requirements = new List<IRequirement>(requirements);
    }

    public void AddRequirement(IRequirement requirement)
    {
        _requirements.Add(requirement);
    }

    public void RemoveSatisfiedRequirements(IReadOnlyAssignments assignments)
    {
        _requirements.RemoveAll(requirement => requirement.IsSatisfied(assignments));
    }

    public int MismatchCost(IReadOnlyAssignments assignments)
    {
        return _requirements.Sum(requirement => requirement.MismatchCost(assignments));
    }

    public bool IsSatisfied(IReadOnlyAssignments assignments)
    {
        return _requirements.All(requirement => requirement.IsSatisfied(assignments));
    }

    public bool IsRuined(IReadOnlyAssignments assignments)
    {
        return _requirements.Any(requirement => requirement.IsRuined(assignments));
    }

    public void MakeSatisfactionAssignment(IAssignments assignments)
    {
        foreach (var requirement in _requirements)
        {
            requirement.MakeSatisfactionAssignment(assignments);
        }
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyAssignments oldAssignments, IReadOnlyAssignments newAssignments)
    {
        return new Requirements(_requirements.Select(requirement => requirement.GetUnsatisfiedReminder(oldAssignments, newAssignments)));
    }

    public Requirements Clone()
    {
        return new Requirements(_requirements);
    }
}