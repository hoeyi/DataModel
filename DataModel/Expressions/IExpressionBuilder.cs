using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ichosys.DataModel.Expressions
{
    /// <summary>
    /// Represents a helper class for building filter expressions.
    /// </summary>
    public interface IExpressionBuilder
    {
        /// <summary>
        /// Gets or sets the additional custom date-time formats used by this <see cref="IExpressionBuilder"/> 
        /// for converting string values to date-time objects.
        /// </summary>
        string[] CustomDateTimeFormats { get; set; }

        /// <summary>
        /// Creates a new <see cref="IQueryParameter{TModel}"/> instance from the given inputs.
        /// </summary>
        /// <typeparam name="TModel">The type being searched.</typeparam>
        /// <param name="memberMetadata">The member metadata to use in the search.</param>
        /// <param name="operator">The operator to use in the search.</param>
        /// <param name="paramValue">The string representation of the parameter value.</param>
        /// <returns>An <see cref="IQueryParameter{TModel}"/> from the inputs.</returns>
        IQueryParameter<TModel> CreateQueryParameter<TModel>(ISearchableMemberMetadata memberMetadata, ComparisonOperator @operator, string paramValue);

        /// <summary>
        /// Creates a reference collection of supported comparison operators.
        /// </summary>
        /// <returns>A collection of <see cref="ComparisonOperator"/> objects.</returns>
        IList<ComparisonOperator> GetComparisonOperators();

        /// <summary>
        /// Creates a dynamic <see cref="Expression{TDelegate}"/> of <see cref="Func{T, TResult}"/>
        /// where <typeparamref name="TModel"/> is the query object type and <paramref name="queryParameter"/> 
        /// is the instance containing the query parameter information.
        /// </summary>
        /// <typeparamref name="TModel"></typeparamref>
        /// <param name="queryParameter">The instance carrying the query parameter information.</param>
        /// <returns>An <see cref="Expression{TDelegate}"/> with <typeparamref name="TModel"/> input type and <see cref="bool"/> return type.</returns>
        Expression<Func<TModel, bool>> GetExpression<TModel>(IQueryParameter<TModel> queryParameter);

        /// <summary>
        /// Creates a reference collection of searchable fields that are members or nested members 
        /// of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A collection of <see cref="ISearchableMemberMetadata"/> objects.</returns>
        IList<ISearchableMemberMetadata> GetSearchableMembers<T>();
    }
}
