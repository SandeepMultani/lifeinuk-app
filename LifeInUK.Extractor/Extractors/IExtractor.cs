namespace LifeInUK.Extractor.Extractors
{
    public interface IExtractor<TOut,TIn>
    {
        TOut Extract(TIn content);
    }
}