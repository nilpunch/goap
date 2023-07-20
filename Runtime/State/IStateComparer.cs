public interface IStateComparer
{
    int HowHardToEqualize(IReadOnlyState first, IReadOnlyState second);
}