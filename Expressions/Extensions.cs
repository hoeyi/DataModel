using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Ichosoft.Expressions.Annotations;

namespace Ichosoft.Expressions
{
    static class Extensions
    {
        /// <summary>
        /// Gets the display data for this member.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns>The <see cref="DisplayAttribute"/> applied to this member, 
        /// or <see cref="null"/> if it does not exist.</returns>
        public static DisplayAttribute GetDisplay(this PropertyInfo propertyInfo)
        {
            // Check the declarying type of a metdatatype.
            // If not found return display
            if (propertyInfo.DeclaringType
                .GetCustomAttribute(typeof(MetadataTypeAttribute)) is not MetadataTypeAttribute metadataType)
                return propertyInfo.GetCustomAttribute<DisplayAttribute>();
            
            // If metdatatype exists return display attribute applied 
            // to member of the same name.
            return metadataType.MetadataClassType
                    .GetProperty(propertyInfo.Name)
                    ?.GetCustomAttribute<DisplayAttribute>();
        }
    }
}
