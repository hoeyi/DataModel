using System;
using System.Resources;

namespace Ichosys.DataModel.Annotations
{
    /// <summary>
    /// Represents a noun that describes the object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NounAttribute : Attribute
    {
        private ResourceManager resourceManager;
        private Type resourceType;

        /// <summary>
        /// Creates a default instance of <see cref="NounAttribute"/>.
        /// </summary>
        /// <remarks>If using resource keys, do not use characters that are illegal for C# names, 
        /// e.g., Object_Singular is valid, Object.Singular is not.</remarks>/// 
        public NounAttribute()
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="Singular"/> attribute property, which may be a resource key string.
        /// <para>
        /// Consumers must use the <see cref="GetSingular"/> method to retrieve the UI display string.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The property contains either the literal, non-localized string or the resource key
        /// to be used in conjunction with <see cref="ResourceType"/> to configure a localized
        /// name for display.
        /// </remarks>
        public string Singular { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SingularArticle"/> attribute property, which may be a resource key string.
        /// <para>
        /// Consumers must use the <see cref="GetSingularArticle"/> method to retrieve the UI display string.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The property contains either the literal, non-localized string or the resource key
        /// to be used in conjunction with <see cref="ResourceType"/> to configure a localized
        /// name for display.
        /// </remarks>
        public string SingularArticle { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Plural"/> attribute property, which may be a resource key string.
        /// <para>
        /// Consumers must use the <see cref="GetPlural"/> method to retrieve the UI display string.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The property contains either the literal, non-localized string or the resource key
        /// to be used in conjunction with <see cref="ResourceType"/> to configure a localized
        /// name for display. Resource keys should not have characters that are illegal for C# names, 
        /// e.g., Object_Singular is valid, Object.Singular is not.
        /// </remarks>
        public string Plural { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PluralArticle"/> attribute property, which may be a resource key string.
        /// <para>
        /// Consumers must use the <see cref="GetPluralArticle"/> method to retrieve the UI display string.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The property contains either the literal, non-localized string or the resource key
        /// to be used in conjunction with <see cref="ResourceType"/> to configure a localized
        /// name for display. Resource keys should not have characters that are illegal for C# names, 
        /// e.g., Object_Singular is valid, Object.Singular is not.
        /// </remarks>
        public string PluralArticle { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> that contains the resources for <see cref="SingularArticle"/>,
        /// <see cref="Singular"/>, <see cref="PluralArticle"/>, and <see cref="Plural"/>.
        /// Using <see cref="ResourceType"/> along with these Key properties, allows these methods to return 
        /// localized values:
        /// <list type="bullet">
        ///     <item><see cref="GetPlural"/></item>
        ///     <item><see cref="GetPluralArticle"/></item>
        ///     <item><see cref="GetSingular"/></item>
        ///     <item><see cref="GetSingularArticle"/></item>
        /// </list>
        /// </summary>

        public Type ResourceType
        {
            get
            { 
                return resourceType; 
            }
            set
            {
                if(resourceType != value)
                {
                    resourceManager = new(resourceSource: value);
                    resourceType = value;
                }
            }
        }

        #region Methods
        /// <summary>
        /// Gets the localized string for the singular nominative form of the noun.
        /// </summary>
        /// <returns>A localized <see cref="string"/>.</returns>
        public string GetSingular()
        {
            if (string.IsNullOrEmpty(Singular))
                return null;

            return resourceManager?.GetString(Singular) ?? Singular;
        }

        /// <summary>
        /// Gets the localized string for the singular nominative article of the noun.
        /// </summary>
        /// <returns>A localized <see cref="string"/>.</returns>
        public string GetSingularArticle()
        {
            if (string.IsNullOrEmpty(SingularArticle))
                return null;

            return resourceManager?.GetString(SingularArticle) ?? SingularArticle;
        }

        /// <summary>
        /// Gets the localized string for the plural nominative form of the noun.
        /// </summary>
        /// <returns>A localized <see cref="string"/>.</returns>
        public string GetPlural()
        {
            if (string.IsNullOrEmpty(Plural))
                return null;

            return resourceManager?.GetString(Plural) ?? Plural;
        }

        /// <summary>
        /// Gets the localized string for the plural nominative article of the noun.
        /// </summary>
        /// <returns>A localized <see cref="string"/>.</returns>
        public string GetPluralArticle()
        {
            if (string.IsNullOrEmpty(PluralArticle))
                return null;

            return resourceManager?.GetString(PluralArticle) ?? PluralArticle;
        }

        #endregion
    }
}
