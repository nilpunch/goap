using System.Collections.Generic;
using System.Linq;

public class Requirements : IRequirement
{
    private readonly List<IRequirement> _requirements;

    public Requirements(IEnumerable<IRequirement> requirements)
    {
        _requirements = new List<IRequirement>(requirements);
    }

    public int MismatchCost(IReadOnlySate sate)
    {
        return _requirements.Sum(requirement => requirement.MismatchCost(sate));
    }

    public bool IsSatisfied(IReadOnlySate sate)
    {
        return _requirements.All(requirement => requirement.IsSatisfied(sate));
    }
}