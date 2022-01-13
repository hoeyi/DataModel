using System;

namespace Ichosoft.Expressions.Annotations
{
    /// <summary>
    /// Allows for flagging properties as searchable using dynamic expression builders.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SearchableAttribute : Attribute
    {
    }
}
