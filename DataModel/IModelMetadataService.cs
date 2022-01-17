using System;
using Ichosoft.DataModel.Annotations;

namespace Ichosoft.DataModel
{
    /// <summary>
    /// Provides methods for accessing object metadata.
    /// </summary>
    public interface IModelMetadataService
    {
        /// <summary>
        /// Gets the attribute applied to the type.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type">The type to check for the attribute.</param>
        /// <returns>A <typeparamref name="TAttribute"/> instance if it exists, else null.</returns>
        TAttribute AttributeFor<TAttribute>(Type type)
            where TAttribute : Attribute;

        /// <summary>
        /// Gets the attribute applied to a member declared within the given type, that 
        /// matches the type parameter.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <param name="type">The declaring type.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>A <typeparamref name="TAttribute"/> instance if it exists, else null.</returns>
        TAttribute AttributeFor<TAttribute>(Type type, string memberName)
            where TAttribute : Attribute;

        /// <summary>
        /// Gets the description for the member declared in the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberName"></param>
        /// <returns>The member description, if defined, else null.</returns>
        string DescriptionFor(Type type, string memberName);

        /// <summary>
        /// Gets the value used to group members.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        string GroupNameFor(Type type, string memberName);

        /// <summary>
        /// Gets the display text for the member declared in the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberName"></param>
        /// <returns>The member display text, if defined, else 
        /// {<see cref="Type.Name"/>.<paramref name="memberName"/>} as an interpolated
        /// <see cref="string"/>.</returns>
        string NameFor(Type type, string memberName);

        /// <summary>
        /// Gets the display order for the member declared in the given type.
        /// </summary>
        /// <param name="type">The declaring type.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member order, if defined, else default <see cref="int?"/>.</returns>
        int? OrderFor(Type type, string memberName);

        /// <summary>
        /// Gets the value used to set the watermark for prompts.
        /// </summary>
        /// <param name="type">The declaring type.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>The prompt watermarks for the member.</returns>
        string PromptFor(Type type, string memberName);

        /// <summary>
        /// Gets the value used for the grid column label.
        /// </summary>
        /// <param name="type">The declaring type.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>The short name for the member.</returns>
        string ShortNameFor(Type type, string memberName);

        /// <summary>
        /// Gets the description for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member description, if defined, else null.</returns>
        string DescriptionFor<TModel>(string memberName);

        /// <summary>
        /// Gets the value used to group members.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member group name, if defined, else null.</returns>
        string GroupNameFor<TModel>(string memberName);

        /// <summary>
        /// Gets the display text for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member display text, if defined, else 
        /// {<see cref="Type.Name"/>.<paramref name="memberName"/>} as an interpolated
        /// <see cref="string"/>.</returns>
        string NameFor<TModel>(string memberName);

        /// <summary>
        /// Gets the display order for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member order, if defined, else default <see cref="int?"/>.</returns>
        int? OrderFor<TModel>(string memberName);

        /// <summary>
        /// Gets the value used to set the watermark for prompts.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The prompt watermarks for the member.</returns>
        string PromptFor<TModel>(string memberName);

        /// <summary>
        /// Gets the value used for the grid column label.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The short name for the member.</returns>
        string ShortNameFor<TModel>(string memberName);
    }
}
