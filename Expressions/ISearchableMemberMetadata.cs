using System.ComponentModel.DataAnnotations;

namespace Ichosoft.Expressions
{
    /// <summary>
    /// Represents a searchable class property.
    /// </summary>
    public interface ISearchableMemberMetadata
    {
        /// <summary>
        /// Gets the display information of the member.
        /// </summary>
        DisplayAttribute Display { get; }

        /// <summary>
        /// Gets the period-delimited member name, excluding the declarying type. 
        /// </summary>
        /// <example>
        ///     From Class:
        ///         Property (direct member)
        ///         Property.SubProperty (member of direct member)
        /// </example>
        /// <remarks>Use this property when constructing search epxressions dynamcially.</remarks>
        string QualifiedMemberName { get; }
    }
}
