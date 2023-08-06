using Common;

namespace GOAP
{
    public interface IRequirement
    {
        int MismatchCost(IReadOnlyState state);

        IActionsLibrary ActionsToHelpSatisfy(IReadOnlyState state) => new EmptyActions();
    }
}