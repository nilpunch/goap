public interface IPropertyEqualizationComplexity<TValue>
{
    float HowHardToEqualize(Property<TValue> first, Property<TValue> second);
}