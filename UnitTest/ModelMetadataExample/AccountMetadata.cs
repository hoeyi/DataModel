using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using Ichosoft.DataModel.UnitTest.Resources;

namespace Ichosoft.DataModel.UnitTest.ModelMetadataExample
{
    [Noun(
        Plural = nameof(DataModelTestString.Account_Plural),
        PluralArticle = nameof(DataModelTestString.Account_PluralArticle),
        Singular = nameof(DataModelTestString.Account_Singular),
        SingularArticle = nameof(DataModelTestString.Account_SingularArticle),
        ResourceType = typeof(DataModelTestString)
        )]
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
