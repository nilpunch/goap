using Common;

namespace GOAP
{
    public class InSameLocation : IRequirement
    {
        private readonly PropertyId _onePosition;
        private readonly PropertyId _otherPosition;
        private readonly int _difficulty;

        public InSameLocation(PropertyId onePosition, PropertyId otherPosition, int difficulty = 1)
        {
            _onePosition = onePosition;
            _otherPosition = otherPosition;
            _difficulty = difficulty;
        }

        public int MismatchCost(IReadOnlyState state)
        {
            return state.Get<Location>(_onePosition) == state.Get<Location>(_otherPosition) ? 0 : _difficulty;
        }
        
        public IActionsLibrary ActionsToHelpSatisfy(IReadOnlyState state)
        {
            if (this.IsSatisfied(state))
            {
                return new EmptyActions();
            }

            var actionsLibrary = new ActionsLibrary();
            actionsLibrary.Add(new Action(new SatisfiedRequirement(), new SetLocationEffect(_onePosition, state.Get<Location>(_otherPosition)), _difficulty, _onePosition + " GoTo " + _otherPosition));
            return actionsLibrary;
        }

        public override string ToString()
        {
            return _onePosition + " == " + _otherPosition;
        }
    }
}