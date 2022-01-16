using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ichosoft.DataModel
{
    /// <summary>
    /// Provides extension methods for <see cref="Type"/> to access member metadata.
    /// </summary>
    public static class ModelMetadataExtension
    {
        private static readonly IModelMetadataService metadataService = 
            new ModelMetadataService();

        /// <summary>
        /// Gets the description for the member declared in the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberName"></param>
        /// <returns>The member description, if defined, else null.</returns>
        public static string DescriptionFor(this Type type, string memberName)
        {
            return metadataService?.DescriptionFor(type, memberName);
        }

        /// <summary>
        /// Gets the value used to group members.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public static string GroupNameFor(this Type type, string memberName)
        {
            return metadataService?.GroupNameFor(type, memberName);
        }

        /// <summary>
        /// Gets the display text for the member declared in the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberName"></param>
        /// <returns>The member display text, if defined, else 
        /// {<see cref="Type.Name"/>.<paramref name="memberName"/>} as an interpolated
        /// <see cref="string"/>.</returns>
        public static string NameFor(this Type type, string memberName)
        {
            return metadataService?.GroupNameFor(type, memberName);
        }

        /// <summary>
        /// Gets the display order for the member declared in the given type.
        /// </summary>
        /// <param name="type">The declaring type.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member order, if defined, else default <see cref="int?"/>.</returns>
        public static int? OrderFor(this Type type, string memberName)
        {
            return metadataService?.OrderFor(type, memberName);
        }

        /// <summary>
        /// Gets the value used to set the watermark for prompts.
        /// </summary>
        /// <param name="type">The declaring type.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>The prompt watermarks for the member.</returns>
        public static string PropmtFor(this Type type, string memberName)
        {
            return metadataService?.PromptFor(type, memberName);
        }

        /// <summary>
        /// Gets the value used for the grid column label.
        /// </summary>
        /// <param name="type">The declaring type.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>The short name for the member.</returns>
        public static string ShortNameFor(this Type type, string memberName)
        {
            return metadataService?.ShortNameFor(type, memberName);
        }
    }
}
