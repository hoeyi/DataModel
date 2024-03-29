﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using Ichosys.DataModel.Tests.Resources;

#nullable disable

namespace Ichosys.DataModel.Tests.ModelExample
{
    [Table("Account", Schema = "EulerApp")]
    [Noun(
        Plural = nameof(DataModelTestString.Account_Plural),
        PluralArticle = nameof(DataModelTestString.Account_PluralArticle),
        Singular = nameof(DataModelTestString.Account_Singular),
        SingularArticle = nameof(DataModelTestString.Account_SingularArticle),
        ResourceType = typeof(DataModelTestString)
        )]
    public partial class Account
    {
        public Account()
        {
        }

        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Required]
        [StringLength(64)]
        [Searchable]
        [Display(
            Description = nameof(DataModelTestString.Display_AccountNumber_Description),
            GroupName = nameof(DataModelTestString.Display_AccountNumber_GroupName),
            Name = nameof(DataModelTestString.Display_AccountNumber_Name),
            Order = default,
            Prompt = nameof(DataModelTestString.Display_AccountNumber_Prompt),
            ShortName = nameof(DataModelTestString.Display_AccountNumber_ShortName),
            ResourceType = typeof(DataModelTestString))]
        [Noun(
            Plural = nameof(DataModelTestString.Account_AccountNumber_Plural),
            PluralArticle = nameof(DataModelTestString.Account_AccountNumber_PluralArticle),
            Singular = nameof(DataModelTestString.Account_AccountNumber_Singular),
            SingularArticle = nameof(DataModelTestString.Account_AccountNumber_SingularArticle),
            ResourceType = typeof(DataModelTestString)
        )]
        public string AccountNumber { get; set; }
        public short DisplayOrder { get; set; }
        [Column("AccountCustodianID")]
        public int? AccountCustodianId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BooksClosedDate { get; set; }
        public bool IsComplianceTradable { get; set; }
        public bool HasWallet { get; set; }
        public bool HasBankTransaction { get; set; }
        public bool HasBrokerTransaction { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(AccountObject.Account))]
        public virtual AccountObject AccountNavigation { get; set; }

        [Display(
            Description = nameof(DataModelTestString.Account_AccountHolder_Description),
            Name = nameof(DataModelTestString.Account_AccountHolder_Name),
            ResourceType = typeof(DataModelTestString))]
        public string AccountHolder { get; }
    }
}
