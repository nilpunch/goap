public interface IPropertyComparer<TValue>
{
    int Difference(TValue first, TValue second);
}