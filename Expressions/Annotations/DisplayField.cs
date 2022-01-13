using System;
using System.Resources;

namespace Ichosoft.Expressions.Annotations
{
    /// <summary>
    /// Provides instruction for retrieving display information for a property 
    /// from an embedded resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DisplayField : Attribute
    {
        private readonly string text;

        /// <summary>
        /// Creates a new <see cref="DisplayField"/> instance.
        /// </summary>
        /// <param name="resource">The resource where the display text resides.</param>
        /// <param name="declaringType">The short name for the declaring type.</param>
        /// <param name="propertyName">The name of the property.</param>
        public DisplayField(Type resource, string declaringType, string propertyName)
            : this(resource, $"{declaringType}.{propertyName}")
        {
        }

        /// <summary>
        /// Creates a new <see cref="DisplayField"/> instance.
        /// </summary>
        /// <param name="resource">The resource where the display text resides.</param>
        /// <param name="key">The key for the display text.</param>
        /// <remarks>This constructor is kept private because interpolated stirngs are in preview.</remarks>
        private DisplayField(Type resource, string key)
        {
            ResourceManager resourceManager = new(resource);
            text = resourceManager?.GetString(key);
        }

        /// <summary>
        /// Gets the display text.
        /// </summary>
        public string Text
        {
            get{ return text; }
        }
    }
}
