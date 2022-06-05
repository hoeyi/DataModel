using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Ichosys.DataModel.Resources;

namespace Ichosys.DataModel.Expressions
{
    /// <summary>
    /// Represents an operator that compares two operands.
    /// </summary>
    public enum ComparisonOperator
    {
        /// <summary>
        /// Represents an operator that returns true if the left operand is equal to the right operand.
        /// </summary>
        [EnumMember(Value = "=")]
        [Display(
            Name = nameof(ComparisonOperatorString.EqualTo), 
            ResourceType = typeof(ComparisonOperatorString))]
        EqualTo,

        /// <summary>
        /// Represents an operator that returns true if the left operand is not equal to the right operand.
        /// </summary>
        [EnumMember(Value = "<>")]
        [Display(
            Name = nameof(ComparisonOperatorString.NotEqualTo), 
            ResourceType = typeof(ComparisonOperatorString))]
        NotEqualTo,

        /// <summary>
        /// Represents an operator that returns true if the left operand is greater than the right operand.
        /// </summary>
        [EnumMember(Value = ">")]
        [Display(
            Name = nameof(ComparisonOperatorString.GreaterThan), 
            ResourceType = typeof(ComparisonOperatorString))]
        GreaterThan,

        /// <summary>
        /// Represents an operator that returns true if the left operand is greater than or equal to the right operand.
        /// </summary>
        [EnumMember(Value = ">=")]
        [Display(
            Name = nameof(ComparisonOperatorString.GreaterThanOrEqualTo), 
            ResourceType = typeof(ComparisonOperatorString))]
        GreaterThanOrEqualTo,
        
        /// <summary>
        /// Represents an operator that returns true if the left operand is less than the right operand.
        /// </summary>
        [EnumMember(Value = "<")]
        [Display(
            Name = nameof(ComparisonOperatorString.LessThan), 
            ResourceType = typeof(ComparisonOperatorString))]
        LessThan,

        /// <summary>
        /// Represents an operator that returns true if the left operand is less than or equal to the right operand.
        /// </summary>
        [EnumMember(Value = "<=")]
        [Display(
            Name = nameof(ComparisonOperatorString.LessThanOrEqualTo), 
            ResourceType = typeof(ComparisonOperatorString))]
        LessThanOrEqualTo,

        /// <summary>
        /// Represents an operator that returns true if the left operand contains the right operand.
        /// </summary>
        [EnumMember(Value = "LIKE %{0}%")]
        [Display(
            Name = nameof(ComparisonOperatorString.Contains), 
            ResourceType = typeof(ComparisonOperatorString))]
        Contains,

        /// <summary>
        /// Represents an operator that returns true if the left operand is null.
        /// </summary>
        [EnumMember(Value = "IS NULL")]
        [Display(
            Name = nameof(ComparisonOperatorString.IsNull), 
            ResourceType = typeof(ComparisonOperatorString))]
        IsNull,

        /// <summary>
        /// Represents an operator that returns true if the left operand is not null.
        /// </summary>
        [EnumMember(Value = "IS NOT NULL")]
        [Display(
            Name = nameof(ComparisonOperatorString.IsNotNull), 
            ResourceType = typeof(ComparisonOperatorString))]
        IsNotNull
    }
}
