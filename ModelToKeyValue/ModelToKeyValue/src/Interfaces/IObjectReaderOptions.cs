namespace ModelToKeyValue.src.Interfaces
{
    public interface IObjectReaderOptions
    {
        bool RequireAttribute { get; set; }
        string NestedSeperator { get; set; }
    }
}
