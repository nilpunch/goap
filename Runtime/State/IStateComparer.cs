public interface IStateComparer
{
    int Difference(IReadOnlyState first, IReadOnlyState second);
}