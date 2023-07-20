using System.Collections.Generic;
using System.Linq;

public class Effect : IEffect
{
    private readonly IEffect[] _effects;

    public Effect(IEffect[] effects)
    {
        _effects = effects;
    }

    public IEnumerable<PropertyId> AffectedProperties => _effects.SelectMany(effect => effect.AffectedProperties);

    public void Modify(IState state)
    {
        foreach (var effect in _effects)
        {
            effect.Modify(state);
        }
    }
}