public class Action : IAction
{
    public Action(IReadOnlyState requirement, IEffect effect, float cost)
    {
        Requirement = requirement;
        Effect = effect;
    }
    
    public IReadOnlyState Requirement { get; }
    public IEffect Effect { get; }
    public float Cost { get; }
}