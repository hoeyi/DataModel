using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosoft.Expressions.Annotations;

#nullable disable

namespace Ichosoft.Expressions.UnitTest.ModelExample
{
    [Table("AccountObject", Schema = "EulerApp")]
    public partial class AccountObject
    {
        public AccountObject()
        {
        }

        [Key]
        [Column("AccountObjectID")]
        public int AccountObjectId { get; set; }
        [Required]
        [StringLength(16)]
        [Searchable]
        [Display(Name = "Account Code")]
        public string AccountObjectCode { get; set; }
        [Required]
        [StringLength(1)]
        public string ObjectType { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CloseDate { get; set; }
        [Required]
        [StringLength(64)]
        public string ObjectDipslayName { get; set; }
        [StringLength(128)]
        public string ObjectDescription { get; set; }
        [Required]
        [StringLength(17)]
        public string PrefixedObjectCode { get; set; }

        [InverseProperty("AccountNavigation")]
        public virtual Account Account { get; set; }
    }
}
