using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ichosoft.Expressions.Annotations;

namespace Ichosoft.Expressions.UnitTest.ModelMetadataExample
{
    public  class AccountMetadata
    {
        [Searchable]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }


    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }
}
