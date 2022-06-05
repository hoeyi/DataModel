using System;
using System.ComponentModel.DataAnnotations;

namespace Ichosys.DataModel.Expressions
{
    /// <summary>
    /// Represents a searchable class property.
    /// </summary>
    class SearchableMemberMetadata : ISearchableMemberMetadata, IEquatable<SearchableMemberMetadata>
    {
        /// <summary>
        /// Gets the display information of the member.
        /// </summary>
        public DisplayAttribute Display { get; set; }

        /// <summary>
        /// Gets the period-delimited member name, excluding the declarying type. 
        /// </summary>
        /// <example>
        ///     From Class:
        ///         Property (direct member)
        ///         Property.SubProperty (member of direct member)
        /// </example>
        /// <remarks>Use this property when constructing search epxressions dynamcially.</remarks>
        public string QualifiedMemberName { get; set; }

        public bool Equals(SearchableMemberMetadata other)
        {
            if (other is null)
                return false;

            return GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Display?.Name, QualifiedMemberName);
        }

        public static bool operator ==(SearchableMemberMetadata lhs, SearchableMemberMetadata rhs)
        {
            if (lhs is null && rhs is null)
                return false;

            else
                return lhs.Equals(rhs);
        }

        public static bool operator !=(SearchableMemberMetadata lhs, SearchableMemberMetadata rhs)
        {
            if (lhs is null && rhs is null)
                return false;

            else
                return !lhs.Equals(rhs);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is SearchableMemberMetadata rhs)
                return Equals(rhs);
            else
                return false;
        }
    }
}
