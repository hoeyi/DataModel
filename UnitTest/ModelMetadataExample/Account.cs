using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ichosoft.Expressions.UnitTest.ModelMetadataExample
{
    public partial class Account
    {
        public string AccountNumber { get; set; }

        public AccountObject AccountNavigation { get; set; }
    }
}
