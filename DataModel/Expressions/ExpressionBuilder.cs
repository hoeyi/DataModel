using System;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;
using Ichosoft.DataModel.Annotations;
using Ichosoft.DataModel.Resources;
using System.ComponentModel.DataAnnotations;

namespace Ichosoft.DataModel.Expressions
{
    #region IExpressionBuilder implementation
    /// <summary>
    /// Represents a helper class for building filter expressions.
    /// </summary>
    public partial class ExpressionBuilder : IExpressionBuilder
    {
        public IList<ComparisonOperator> GetComparisonOperators()
        {
            var members = Enum.GetValues(typeof(ComparisonOperator))
                .Cast<ComparisonOperator>();

            return members.ToList();
        }

        public Expression<Func<TModel,bool>> GetExpression<TModel>(
            IQueryParameter<TModel> queryParameter)
        {
            var type = typeof(TModel);
            var memberInfo = queryParameter.MemberName.Split(".");

            PropertyInfo outerPropertyInfo = type.GetProperty(memberInfo[0]);

            // Construct the base elements of the left-hand side of the expression.
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "x");
            Expression expressionLeft = Expression.Property(parameterExpression, propertyName: outerPropertyInfo.Name);
            Expression expressionRight;

            // Handle direct class member scenario.
            if(memberInfo.Length == 1)
            {
                // Check query parameter information is supported.
                ValidateOrThrow(queryParameter.Operator, outerPropertyInfo);

                // Build right-hand side with the search value.
                expressionRight = queryParameter.Operator == ComparisonOperator.IsNull || queryParameter.Operator == ComparisonOperator.IsNotNull ?
                    Expression.Constant(null) : ParseSearchConstant(value: queryParameter.Value, type: outerPropertyInfo.PropertyType);

                // Conver the right-hand side to the appropriate type. Handles support for nullable property types.
                expressionRight = Expression.Convert(expressionRight, type: outerPropertyInfo.PropertyType);
            }

            // Handles single-level nested class member scenario.
            else if(memberInfo.Length == 2)
            {
                PropertyInfo innerPropertyInfo = outerPropertyInfo.PropertyType.GetProperty(memberInfo[1]);

                // Check query parameter information is supported.
                ValidateOrThrow(queryParameter.Operator, innerPropertyInfo);

                // Add the inner property to the left-hand side of the expression.
                expressionLeft = Expression.Property(expressionLeft, propertyName: innerPropertyInfo.Name);

                // Build right-hand side with the search value.
                expressionRight = queryParameter.Operator == ComparisonOperator.IsNull || queryParameter.Operator == ComparisonOperator.IsNotNull ?
                    Expression.Constant(null) : ParseSearchConstant(value: queryParameter.Value, type: innerPropertyInfo.PropertyType);

                // Conver the right-hand side to the appropriate type. Handles support for nullable property types.
                expressionRight = Expression.Convert(expressionRight, type: innerPropertyInfo.PropertyType);
            }
            else
            {
                throw new NotSupportedException(message: ExceptionString.Expression_NestingNotSupported);
            }

            try
            {
                // Combine the left- and right-hand sides with the appropriate method.
                Expression expression = queryParameter.Operator switch
                {
                    ComparisonOperator.EqualTo => Expression.Equal(expressionLeft, expressionRight),
                    ComparisonOperator.NotEqualTo => Expression.NotEqual(expressionLeft, expressionRight),
                    ComparisonOperator.GreaterThan => Expression.GreaterThan(expressionLeft, expressionRight),
                    ComparisonOperator.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(expressionLeft, expressionRight),
                    ComparisonOperator.LessThan => Expression.LessThan(expressionLeft, expressionRight),
                    ComparisonOperator.LessThanOrEqualTo => Expression.LessThanOrEqual(expressionLeft, expressionRight),
                    ComparisonOperator.Contains => Expression.Call(expressionLeft, nameof(string.Contains), null, expressionRight),
                    ComparisonOperator.IsNull => Expression.Equal(expressionLeft, expressionRight),
                    ComparisonOperator.IsNotNull => Expression.NotEqual(expressionLeft, expressionRight),

                    _ => throw new InvalidOperationException(),
                };

                return Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);
            }
            catch(Exception e)
            {
                throw new Exceptions.ParseException(message: ExceptionString.Expression_General, e);
            }
        }
        
        public IList<ISearchableMemberMetadata> GetSearchableMembers<T>()
        {
            // Local method for getting the searchable members of a given type.
            static IEnumerable<PropertyInfo> getSearchableMembers(Type type)
            {
                return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Where(p => p.HasAttribute<SearchableAttribute>());
            }

            var baseType = typeof(T);

            // Get the searchable members for the base type.
            var baseSearchableMembers = getSearchableMembers(baseType)
                                    .Select(p =>
                                    {
                                        var display = p.GetAttribute<DisplayAttribute>();
                                        return new SearchableMemberMetadata()
                                        {
                                            Display = display,
                                            QualifiedMemberName = p.Name
                                        };
                                    });

            // Get the searchable members for members of object properties
            // contained in the base type.
            var nestedPropertyQuery = baseType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                            .Select(p => (p.Name, getSearchableMembers(p.PropertyType)));


            var nestedSearchableMembers = (from p in nestedPropertyQuery
                                           from q in p.Item2
                                           select new
                                           {
                                               BasePropertyName = p.Name,
                                               SearchableProperty = q
                                           })
                                           .Select(p =>
                                           {
                                               var display = p.SearchableProperty.GetAttribute<DisplayAttribute>();
                                               return new SearchableMemberMetadata()
                                               {
                                                   Display = display,
                                                   QualifiedMemberName = $"{p.BasePropertyName}.{p.SearchableProperty.Name}"
                                               };
                                           });

            var combinedResults = baseSearchableMembers.Concat(nestedSearchableMembers).Where(p => p.Display is not null);
            return combinedResults.Cast<ISearchableMemberMetadata>().ToList();
        }
    }
    #endregion

    public partial class ExpressionBuilder
    {
        /// <summary>
        /// Creates a constant (RHS) expression given a string and expected type.
        /// </summary>
        /// <param name="value">The string representation the constant value.</param>
        /// <param name="type">The type to which the <paramref name="value"/> will be converted.</param>
        /// <returns>A <see cref="ConstantExpression"/> representing the right-hand side of a comparison.</returns>
        private static ConstantExpression ParseSearchConstant(string value, Type type)
        {
            // Adjust the parameter type for nullable data types.
            var parameterType = Nullable.GetUnderlyingType(type) ?? type;

            return parameterType.FullName switch
            {
                "System.String" => Expression.Constant(value: value, type: parameterType),
                "System.DateTime" => Expression.Constant(value: Converter.TryParseDateTime(value.ToString()), type: parameterType),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// Validates the given <see cref="ComparisonOperator"/> is valid for use with the given <see cref="PropertyInfo"/>.
        /// Throws a <see cref="NotSupportedException"/> if the use is invalid.
        /// </summary>
        /// <param name="operator">The operator to check.</param>
        /// <param name="property">The property to check</param>
        private static void ValidateOrThrow(ComparisonOperator @operator, PropertyInfo property)
        {
            if (property is null)
                throw new ArgumentNullException(paramName: nameof(property));

            var underlyingType = Nullable.GetUnderlyingType(property.PropertyType);

            // Get the underlying type if property type is nullable.
            var type = underlyingType ?? property.PropertyType;
            var typeIsNullable = !(underlyingType is null);

            // Define comparisons valid for numeric types.
            var numericOperators = new ComparisonOperator[]
            {
                ComparisonOperator.EqualTo,
                ComparisonOperator.NotEqualTo,
                ComparisonOperator.GreaterThan,
                ComparisonOperator.GreaterThanOrEqualTo,
                ComparisonOperator.LessThan,
                ComparisonOperator.LessThanOrEqualTo
            };

            // Define comparisons valid for text types.
            var textOperators = new ComparisonOperator[]
            {
                ComparisonOperator.EqualTo,
                ComparisonOperator.NotEqualTo,
                ComparisonOperator.Contains,
                ComparisonOperator.IsNull,
                ComparisonOperator.IsNotNull
            };

            if(typeIsNullable)
            {
                Array.Resize(ref numericOperators, numericOperators.Length + 2);
                numericOperators[^2] = ComparisonOperator.IsNull;
                numericOperators[^1] = ComparisonOperator.IsNotNull;
            }

            

            // Map the types to their supported operators.
            var typeOperatorLookup = new Dictionary<Type, ComparisonOperator[]>()
            {
                { typeof(short), numericOperators },
                { typeof(int), numericOperators },
                { typeof(long), numericOperators },
                { typeof(float), numericOperators },
                { typeof(double), numericOperators },
                { typeof(decimal), numericOperators },
                { typeof(DateTime), numericOperators },

                { typeof(char), textOperators },
                { typeof(string), textOperators },
            };

            // Throw exception if mapped array does not contain the comparison operator, or if 
            // the mapping does not contain the type.
            if (!typeOperatorLookup.ContainsKey(type) ||
                !typeOperatorLookup[type].Contains(@operator))
            {
                string operatorDisplayName = typeof(ComparisonOperator)
                    .GetMember(memberName: $"{@operator}")
                    ?.GetAttribute<DisplayAttribute>()
                    ?.GetName() ?? $"{typeof(ComparisonOperator).Name}.{@operator}";

                throw new NotSupportedException(
                    string.Format(ExceptionString.Expression_OperatorInvalidForField, operatorDisplayName));
            }
        }
    }
}
