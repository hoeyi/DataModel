using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using Ichosoft.DataModel.UnitTest.Resources;

namespace Ichosoft.DataModel.UnitTest.ModelMetadataExample
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
