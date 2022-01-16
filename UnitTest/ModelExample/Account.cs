using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosoft.DataModel.Annotations;
using Ichosoft.DataModel.UnitTest.Resources;

#nullable disable

namespace Ichosoft.DataModel.UnitTest.ModelExample
{
    [Table("Account", Schema = "EulerApp")]
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
            Name = nameof(DataModelTestString.Account_AccountNumber), 
            ResourceType = typeof(DataModelTestString))]
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
    }
}
