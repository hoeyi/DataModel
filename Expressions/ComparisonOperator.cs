using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Ichosoft.Expressions
{
    public enum ComparisonOperator
    {
        [EnumMember(Value = "=")]
        [Display(Name = nameof(EqualTo), ResourceType = typeof(Resources.ComparisonOperator))]
        EqualTo,

        [EnumMember(Value = "<>")]
        [Display(Name = nameof(NotEqualTo), ResourceType = typeof(Resources.ComparisonOperator))]
        NotEqualTo,

        [EnumMember(Value = ">")]
        [Display(Name = nameof(GreaterThan), ResourceType = typeof(Resources.ComparisonOperator))]
        GreaterThan,

        [EnumMember(Value = ">=")]
        [Display(Name = nameof(GreaterThanOrEqualTo), ResourceType = typeof(Resources.ComparisonOperator))]
        GreaterThanOrEqualTo,

        [EnumMember(Value = "<")]
        [Display(Name = nameof(LessThan), ResourceType = typeof(Resources.ComparisonOperator))]
        LessThan,

        [EnumMember(Value = "<=")]
        [Display(Name = nameof(LessThanOrEqualTo), ResourceType = typeof(Resources.ComparisonOperator))]
        LessThanOrEqualTo,

        [EnumMember(Value = "LIKE %{0}%")]
        [Display(Name = nameof(Contains), ResourceType = typeof(Resources.ComparisonOperator))]
        Contains,

        [EnumMember(Value = "IS NULL")]
        [Display(Name = nameof(IsNull), ResourceType = typeof(Resources.ComparisonOperator))]
        IsNull,

        [EnumMember(Value = "IS NOT NULL")]
        [Display(Name = nameof(IsNotNull), ResourceType = typeof(Resources.ComparisonOperator))]
        IsNotNull
    }
}
