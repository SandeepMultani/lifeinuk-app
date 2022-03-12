namespace LifeInUK.Extractor.Options
{
    public class DatabaseOptions
    {
        public const string Selector = "LifeInUKDatabase";
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}