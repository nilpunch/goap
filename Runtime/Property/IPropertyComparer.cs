public interface IPropertyComparer<TValue>
{
    int HowHardToEqualize(Property<TValue> first, Property<TValue> second);
}