public interface IPropertyComparer<TValue>
{
    int HowHardToEqualize(TValue first, TValue second);
}