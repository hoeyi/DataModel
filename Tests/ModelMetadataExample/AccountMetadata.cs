using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;
using Ichosys.DataModel.Tests.Resources;

namespace Ichosys.DataModel.Tests.ModelMetadataExample
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
            Name = nameof(DataModelTestString.Display_AccountNumber_Name),
            ResourceType = typeof(DataModelTestString))]
        [Noun(
            Plural = nameof(DataModelTestString.Account_AccountNumber_Plural),
            PluralArticle = nameof(DataModelTestString.Account_AccountNumber_PluralArticle),
            Singular = nameof(DataModelTestString.Account_AccountNumber_Singular),
            SingularArticle = nameof(DataModelTestString.Account_AccountNumber_SingularArticle),
            ResourceType = typeof(DataModelTestString)
        )]
        public string AccountNumber { get; set; }


    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }
}
