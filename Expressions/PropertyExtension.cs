using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Ichosoft.Expressions.Annotations;
using System;

namespace Ichosoft.Expressions
{
    static class PropertyExtension
    {
        /// <summary>
        /// Gets the display data for this member.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns>The <see cref="DisplayAttribute"/> applied to this member, 
        /// or <see cref="null"/> if it does not exist.</returns>
        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute :  Attribute
        {
            TAttribute attribute;

            // Check the declarying type of a metdatatype.
            // If not found return display
            if (propertyInfo.DeclaringType
                .GetCustomAttribute(typeof(MetadataTypeAttribute)) is not MetadataTypeAttribute metadataType)
            {
                attribute = propertyInfo.GetCustomAttribute<TAttribute>();
            }
            else
            {
                // If metdatatype exists return display attribute applied 
                // to member of the same name.
                attribute = metadataType.MetadataClassType
                    .GetProperty(propertyInfo.Name)
                    ?.GetCustomAttribute<TAttribute>();
            }

            return attribute;
        }

        public static bool HasAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            bool result;
            // Check the declarying type of a metdatatype.
            // If not found return display
            if (propertyInfo.DeclaringType
                .GetCustomAttribute(typeof(MetadataTypeAttribute)) is not MetadataTypeAttribute metadataType)
            {
                result = propertyInfo.GetCustomAttribute<TAttribute>() is not null;
                
            }
            else
            {
                // If metdatatype exists return display attribute applied 
                // to member of the same name.
                result = metadataType.MetadataClassType
                        .GetProperty(propertyInfo.Name)
                        ?.GetCustomAttribute<TAttribute>() is not null;

            }

            return result;
        }
    }
}
