using GOAP.Effects;
using GOAP.Requirements;

namespace GOAP.Actions
{
    public interface IAction
    {
        IRequirement Requirement { get; }
        IEffect Effect { get; }
        int Cost { get; }
    }
}