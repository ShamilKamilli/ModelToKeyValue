using System;

namespace ModelToKeyValue.src.Attributes
{
    /// <summary>
    /// sign propert for serialize
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
   public sealed class SerializableObjectAttribute : Attribute { }
}
