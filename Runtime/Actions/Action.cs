namespace GOAP
{
    public class Action<TState> : IAction<TState>
    {
        private readonly string _name;

        public Action(IRequirement<TState> requirement, IEffect<TState> effect, int cost, string name = "")
        {
            Requirement = requirement;
            Effect = effect;
            Cost = cost;
            _name = name;
        }
    
        public IRequirement<TState> Requirement { get; }
        public IEffect<TState> Effect { get; }
        public int Cost { get; }

        public override string ToString()
        {
            return _name;
        }
    }
}