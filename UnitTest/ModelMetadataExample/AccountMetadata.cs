using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using Ichosoft.DataModel.UnitTest.Resources;

namespace Ichosoft.DataModel.UnitTest.ModelMetadataExample
{
    public  class AccountMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(DataModelTestString.Account_AccountNumber),
            ResourceType = typeof(DataModelTestString))]
        public string AccountNumber { get; set; }


    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }
}
