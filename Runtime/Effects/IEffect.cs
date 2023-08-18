using Common;

namespace GOAP
{
    public interface IEffect
    {
        void Modify(IState state);
        bool IsChangeSomething(IReadOnlyState state);
    }
}