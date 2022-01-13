using System.Runtime.Serialization;

namespace Ichosoft.Expressions
{
    public enum ComparisonOperator
    {
        [EnumMember(Value = "=")]
        EqualTo,

        [EnumMember(Value = "<>")]
        NotEqualTo,

        [EnumMember(Value = ">")]
        GreaterThan,

        [EnumMember(Value = ">=")]
        GreaterThanOrEqualTo,

        [EnumMember(Value = "<")]
        LessThan,

        [EnumMember(Value = "<=")]
        LessThanOrEqualTo,

        [EnumMember(Value = "LIKE %{0}%")]
        Contains,

        [EnumMember(Value = "IS NULL")]
        IsNull,

        [EnumMember(Value = "IS NOT NULL")]
        IsNotNull
    }
}
