public interface IStateEqualizationComplexity
{
    float HowHardToEqualize(IReadOnlyState first, IReadOnlyState second);
}