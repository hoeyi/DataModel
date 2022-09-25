using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Ichosys.DataModel.Annotations;

[assembly: InternalsVisibleTo("Ichosys.DataModel.Tests")]

namespace Ichosys.DataModel
{
    /// <summary>
    /// Provides methods for accessing object metadata.
    /// </summary>
    public partial interface IModelMetadataService
    {
        /// <summary>
        /// Gets the first <typeparamref name="TAttribute"/> associated with the 
        /// <typeparamref name="TModel"/> type.
        /// </summary>
        /// <typeparam name="TModel">The type decorated with <typeparamref name="TAttribute"/>.</typeparam>
        /// <typeparam name="TAttribute">The attribute type to retreive.</typeparam>
        /// <returns>An instance of <typeparamref name="TAttribute"/> if defined, else null.</returns>
        TAttribute GetAttribute<TModel, TAttribute>()
            where TAttribute : Attribute
            => typeof(TModel).GetAttribute<TAttribute>();

        /// <summary>
        /// Gets the <typeparamref name="TAttribute"/> associated with the <typeparamref name="TModel"/> 
        /// member indicated by the given expression.
        /// </summary>
        /// <typeparam name="TAttribute">A type derived from <see cref="Attribute"/>.</typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="expression"></param>
        /// <returns>An instance of <typeparamref name="TAttribute"/> if defined, else null.</returns>
        TAttribute AttributeFor<TAttribute, TModel>(Expression<Func<TModel, object>> expression)
            where TAttribute : Attribute
            => GetAttribute<TModel, TAttribute>(expression);

        /// <summary>
        /// Gets the description text associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="Type"/> in which the selected property is declared.</typeparam>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="TModel"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string DescriptionFor<TModel>(Expression<Func<TModel, object>> expression) =>
            GetDisplayAttribute(expression)?.GetDescription();

        /// <summary>
        /// Gets the group name associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="Type"/> in which the selected property is declared.</typeparam>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="TModel"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string GroupNameFor<TModel>(Expression<Func<TModel, object>> expression) =>
            GetDisplayAttribute(expression)?.GetGroupName();

        /// <summary>
        /// Gets the display name associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="Type"/> in which the selected property is declared.</typeparam>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="TModel"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string NameFor<TModel>(Expression<Func<TModel, object>> expression) =>
            GetDisplayAttribute(expression)?.GetName();

        /// <summary>
        /// Gets the display order associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="Type"/> in which the selected property is declared.</typeparam>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="TModel"/> member.</param>
        /// <returns>An <see cref="int"/> if the metadata property is defined, else null.</returns>
        int? OrderFor<TModel>(Expression<Func<TModel, object>> expression) =>
            GetDisplayAttribute(expression)?.GetOrder();

        /// <summary>
        /// Gets the input prompt associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="Type"/> in which the selected property is declared.</typeparam>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="TModel"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string PromptFor<TModel>(Expression<Func<TModel, object>> expression) =>
            GetDisplayAttribute(expression)?.GetPrompt();

        /// <summary>
        /// Gets the short name associated with the <typeparamref name="TModel"/> member 
        /// found at the endpoint of the given expression.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="Type"/> in which the selected property is declared.</typeparam>
        /// <param name="expression">An <see cref="Expression{TDelegate}"/> seleting a public 
        /// <typeparamref name="TModel"/> member.</param>
        /// <returns>A <see cref="string"/> if the metadata property is defined, else null.</returns>
        string ShortNameFor<TModel>(Expression<Func<TModel, object>> expression) =>
            GetDisplayAttribute(expression)?.GetShortName();
    }

    // Helper methods.
    public partial interface IModelMetadataService
    {
        /// <summary>
        /// Gets the <see cref="MemberInfo"/> instance from the given <see cref="Expression{TDelegate}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns>An instance of <see cref="MemberInfo"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception> 
        /// <exception cref="NotSupportedException"></exception>
        private static MemberInfo GetMemberInfo<T>(Expression<Func<T, object>> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            LambdaExpression lambda = expression;
            if (lambda is null)
                throw new NotSupportedException();

            MemberExpression memberExpr = lambda.Body.NodeType switch
            {
                ExpressionType.Convert => ((UnaryExpression)lambda.Body).Operand as MemberExpression,
                ExpressionType.MemberAccess => lambda.Body as MemberExpression,
                _ => throw new NotSupportedException()
            };

            return memberExpr.Member;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static DisplayAttribute GetDisplayAttribute<T>(
            Expression<Func<T, object>> expression)
        {
            if (expression is null) return null;

            MemberInfo memberInfo = GetMemberInfo(expression);

            return memberInfo?.GetAttribute<DisplayAttribute>();
        }

        private static TAttribute GetAttribute<T, TAttribute>(
            Expression<Func<T, object>> expression)
            where TAttribute : Attribute
        {
            if (expression is null)
                return null;

            MemberInfo memberInfo = GetMemberInfo(expression);

            return memberInfo?.GetAttribute<TAttribute>();
        }
    }

    /// <summary>
    /// Provides methods for accessing object metadata.
    /// </summary>
    public class ModelMetadataService : IModelMetadataService
    {
    }
}
