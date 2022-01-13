using System;

namespace Ichosoft.Expressions
{
    public class QueryParameter<TModel> : IQueryParameter<TModel>
    {
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
