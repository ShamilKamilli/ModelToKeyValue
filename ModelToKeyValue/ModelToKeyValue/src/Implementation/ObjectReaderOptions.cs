using ModelToKeyValue.src.Interfaces;

namespace ModelToKeyValue.src.Implementation
{
    public class ObjectReaderOptions : IObjectReaderOptions
    {
        public bool RequireAttribute { get; set; }

        public string NestedSeperator { get; set; }
    }
}
