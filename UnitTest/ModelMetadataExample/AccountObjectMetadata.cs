using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ichosoft.Expressions.Annotations;

namespace Ichosoft.Expressions.UnitTest.ModelMetadataExample
{
    public class AccountObjectMetadata
    {
        [Searchable]
        [Display(Name = "Account Code")]
        public string AccountObjectCode { get; set; }
    }

    [MetadataType(typeof(AccountObjectMetadata))]
    public partial class AccountObject
    {
    }
}
