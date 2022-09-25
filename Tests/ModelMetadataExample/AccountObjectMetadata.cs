using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;
using Ichosys.DataModel.Tests.Resources;

namespace Ichosys.DataModel.Tests.ModelMetadataExample
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
