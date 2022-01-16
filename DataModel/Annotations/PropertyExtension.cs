using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System;

namespace Ichosoft.DataModel.Annotations
{
    /// <summary>
    /// Extension methods for <see cref="PropertyInfo"/> to support 
    /// <see cref="MetadataTypeAttribute"/> patterns.
    /// </summary>
    public static class PropertyExtension
    {
        /// <summary>
        /// Gets the first <typeparamref name="TAttribute"/> applied to this member.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <param name="memberInfo">The <see cref="MemberInfo"/> representing the member.</param>
        /// <returns>A <typeparamref name="TAttribute"/> if one exists, else null.</returns>
        /// /// <remarks>This method supports classes using a <see cref="MetadataTypeAttribute"/> pattern.</remarks>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo memberInfo)
            where TAttribute : Attribute
        {
            TAttribute attribute;

            // Check the declarying type of a metdatatype.
            // If not found return display
            if (memberInfo.DeclaringType
                .GetCustomAttribute(typeof(MetadataTypeAttribute)) is not MetadataTypeAttribute metadataType)
            {
                attribute = memberInfo.GetCustomAttribute<TAttribute>();
            }
            else
            {
                // If metdatatype exists return display attribute applied 
                // to member of the same name.
                attribute = metadataType.MetadataClassType
                    .GetProperty(memberInfo.Name)
                    ?.GetCustomAttribute<TAttribute>();
            }

            return attribute;
        }

        /// <summary>
        /// Checks whether the member has an attribute matching <typeparamref name="TAttribute"/> applied.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <param name="memberInfo">The <see cref="MemberInfo"/> representing the member.</param>
        /// <returns>True if the attribute is applied, else false.</returns>
        /// <remarks>This method supports classes using a <see cref="MetadataTypeAttribute"/> pattern.</remarks>
        public static bool HasAttribute<TAttribute>(this MemberInfo memberInfo)
            where TAttribute : Attribute
        {
            bool result;
            // Check the declarying type of a metdatatype.
            // If not found return display
            if (memberInfo.DeclaringType
                .GetCustomAttribute(typeof(MetadataTypeAttribute)) is not MetadataTypeAttribute metadataType)
            {
                result = memberInfo.GetCustomAttribute<TAttribute>() is not null;

            }
            else
            {
                // If metdatatype exists return display attribute applied 
                // to member of the same name.
                result = metadataType.MetadataClassType
                        .GetProperty(memberInfo.Name)
                        ?.GetCustomAttribute<TAttribute>() is not null;

            }

            return result;
        }

        /// <summary>
        /// Gets the first <typeparamref name="TAttribute"/> applied to this member.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <param name="propertyInfo">The <see cref="PropertyInfo"/> representing the member.</param>
        /// <returns>A <typeparamref name="TAttribute"/> if one exists, else null.</returns>
        /// /// <remarks>This method supports classes using a <see cref="MetadataTypeAttribute"/> pattern.</remarks>
        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute :  Attribute
        {
            return GetAttribute<TAttribute>(memberInfo: propertyInfo);
        }

        /// <summary>
        /// Checks whether the member has an attribute matching <typeparamref name="TAttribute"/> applied.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <param name="propertyInfo">The <see cref="PropertyInfo"/> representing the member.</param>
        /// <returns>True if the attribute is applied, else false.</returns>
        /// <remarks>This method supports classes using a <see cref="MetadataTypeAttribute"/> pattern.</remarks>
        public static bool HasAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return HasAttribute<TAttribute>(memberInfo: propertyInfo);
        }
    }
}
