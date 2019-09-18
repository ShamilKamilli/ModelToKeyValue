using ModelToKeyValue.src.Models;
using System.Collections.Generic;

namespace ModelToKeyValue.src.Interfaces
{
    public interface IObjectReader
    {
        List<ObjectReaderModel> GetStrings(object data);
    }
}
