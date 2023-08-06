using Common;

namespace GOAP.Effects
{
    public interface IEffect
    {
        void Modify(IState state);
        bool IsChangeSomething(IReadOnlyState state);
    }
}