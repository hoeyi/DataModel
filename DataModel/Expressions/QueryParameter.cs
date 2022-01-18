using System;

namespace Ichosoft.DataModel.Expressions
{
    /// <summary>
    /// Represents a paramter used to filter search results.
    /// </summary>
    /// <typeparam name="TModel">The member type to be evaluated.</typeparam>
    class QueryParameter<TModel> : IQueryParameter<TModel>
    {
        /// <summary>
        /// Creates a new <see cref="QueryParameter{TModel}"/> instance from the given inputs.
        /// </summary>
        /// <param name="memberMetadata">The member metadata to use in the search.</param>
        /// <param name="operator">The operator to use in the search.</param>
        /// <param name="paramValue">The string representation of the parameter value.</param>
        public QueryParameter(
            ISearchableMemberMetadata memberMetadata, ComparisonOperator @operator, string paramValue)
            : this(memberMetadata?.QualifiedMemberName, @operator, paramValue)
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="QueryParameter{TModel}"/> from inputs.
        /// </summary>
        /// <param name="qualifiedMemberName">The qualified member name relative to the searched type.</param>
        /// <param name="operator">A <see cref="ComparisonOperator"/>.</param>
        /// <param name="paramValue">A string representation of the parameter value.</param>
        public QueryParameter(string qualifiedMemberName, ComparisonOperator @operator, string paramValue)
        {
            if (string.IsNullOrEmpty(qualifiedMemberName))
                throw new ArgumentNullException(paramName: nameof(qualifiedMemberName));

            MemberName = qualifiedMemberName;
            Operator = @operator;
            Value = @operator == ComparisonOperator.IsNull ? null : paramValue;
        }
        public Type SearchObjectType { get => typeof(TModel); }

        public string MemberName { get; }

        public ComparisonOperator Operator { get; }

        public string Value { get; }
    }
}
