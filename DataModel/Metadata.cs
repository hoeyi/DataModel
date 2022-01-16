using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ichosoft.DataModel.Annotations;

namespace Ichosoft.DataModel
{
    /// <summary>
    /// Contains methods for extracting metaata for classes and enums.
    /// </summary>
    public static class Metadata
    {
        /// <summary>
        /// Gets the <see cref="FieldInfo"/> for <see cref="Enum"/> types, 
        /// else gets the <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/>.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>A <see cref="MemberInfo"/> if a match is found, else null.</returns>
        static MemberInfo GetMember(
            this Type type, 
            string memberName)
        {
            return type.IsEnum ? 
                type.GetField(memberName) : 
                type.GetProperty(memberName, BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets the display text for a given class and member.
        /// </summary>
        /// <typeparam name="TModel">The declaring type of the member.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The display text as a <see cref="string"/>, if found, else null.</returns>
        public static string DisplayTextFor<TModel>(string memberName)
        {
            Type type = typeof(TModel);
            MemberInfo memberInfo = type.GetMember(memberName: memberName);

            return memberInfo
                ?.GetAttribute<DisplayAttribute>()
                ?.GetName() ?? $"{type.Name}.{memberName}";
        }
    }
}
