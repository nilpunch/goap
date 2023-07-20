public class Action : IAction
{
    private readonly string _name;

    public Action(IReadOnlyState requirement, IEffect effect, int cost, string name = "")
    {
        Requirement = requirement;
        Effect = effect;
        Cost = cost;
        _name = name;
    }
    
    public IReadOnlyState Requirement { get; }
    public IEffect Effect { get; }
    public int Cost { get; }

    public override string ToString()
    {
        return _name;
    }
}