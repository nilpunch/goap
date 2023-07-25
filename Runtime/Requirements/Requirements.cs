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

    public void RemoveSatisfiedRequirements(IReadOnlyState state)
    {
        _requirements.RemoveAll(requirement => requirement.IsSatisfied(state));
    }

    public int MismatchCost(IReadOnlyState state)
    {
        return _requirements.Sum(requirement => requirement.MismatchCost(state));
    }

    public bool IsSatisfied(IReadOnlyState state)
    {
        return _requirements.All(requirement => requirement.IsSatisfied(state));
    }

    public void SatisfyState(IState state)
    {
        foreach (var requirement in _requirements)
        {
            requirement.SatisfyState(state);
        }
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyState oldState, IReadOnlyState newState)
    {
        return new Requirements(_requirements.Select(requirement => requirement.GetUnsatisfiedReminder(oldState, newState)));
    }

    public Requirements Clone()
    {
        return new Requirements(_requirements);
    }
}