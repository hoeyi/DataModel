using System;

namespace Ichosoft.DataModel.Expressions
{
    /// <summary>
    /// Reprsents a paramter used to filter search results.
    /// </summary>
    /// <typeparam name="TModel">The member type to be evaluated.</typeparam>
    class QueryParameter<TModel> : IQueryParameter<TModel>
    {
        /// <summary>
        /// Returns a 
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="operator"></param>
        /// <param name="paramValue"></param>
        public QueryParameter(string memberName, ComparisonOperator @operator, string paramValue)
        {
            if (string.IsNullOrEmpty(memberName))
                throw new ArgumentNullException(Resources.ExceptionString.Expression_SearchMemberNull);

            MemberName = memberName;
            Operator = @operator;
            Value = @operator == ComparisonOperator.IsNull ? null : paramValue;
        }

        public Type SearchObjectType { get => typeof(TModel); }

        public string MemberName { get; }

        public ComparisonOperator Operator { get; }

        public string Value { get; }
    }
}
