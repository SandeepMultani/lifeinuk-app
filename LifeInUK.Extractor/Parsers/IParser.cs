namespace LifeInUK.Extractor.Parsers
{
    public interface IParser<T>
    {
        T Parse(string content);
    }
}