using System.Linq;

public class Effect : IEffect
{
    private readonly IEffect[] _effects;

    public Effect(IEffect[] effects)
    {
        _effects = effects;
    }

    public void Modify(IState state)
    {
        _effects.ForEach(effect => effect.Modify(state));
    }

    public bool IsChangeSomething(IReadOnlySate state)
    {
        return _effects.Any(effect => effect.IsChangeSomething(state));
    }
}