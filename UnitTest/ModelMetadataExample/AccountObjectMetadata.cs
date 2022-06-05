using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;
using Ichosys.DataModel.UnitTest.Resources;

namespace Ichosys.DataModel.UnitTest.ModelMetadataExample
{
    public class AccountObjectMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(DataModelTestString.AccountObject_AccountObjectCode),
            ResourceType = typeof(DataModelTestString))]
        public string AccountObjectCode { get; set; }
    }

    [MetadataType(typeof(AccountObjectMetadata))]
    public partial class AccountObject
    {
    }
}
