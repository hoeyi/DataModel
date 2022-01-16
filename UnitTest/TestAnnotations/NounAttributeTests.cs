using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosoft.DataModel.Annotations;
using Ichosoft.DataModel.UnitTest.Resources;

namespace Ichosoft.DataModel.UnitTest.TestAnnotations
{
    [TestClass]
    public class NounAttributeTests
    {
        [TestMethod]
        public void NounAttribute_ValidResourceKeys_YeildsExpectedStrings()
        {
            var nounAttribute = typeof(ExampleClass).GetProperty(nameof(ExampleClass.ExampleProperty))
                ?.GetAttribute<NounAttribute>();

            Assert.AreEqual(NounString.Test_SingularArticle, nounAttribute?.GetSingularArticle());
            Assert.AreEqual(NounString.Test_Singular, nounAttribute?.GetSingular());
            Assert.AreEqual(NounString.Test_PluralArticle, nounAttribute?.GetPluralArticle());
            Assert.AreEqual(NounString.Test_Plural, nounAttribute?.GetPlural());
        }
        public class ExampleClass
        {
            [Noun(
                Singular = nameof(NounString.Test_Singular),
                SingularArticle = nameof(NounString.Test_SingularArticle),
                Plural = nameof(NounString.Test_Plural),
                PluralArticle = nameof(NounString.Test_PluralArticle),
                ResourceType = typeof(NounString)
                )]
            public string ExampleProperty { get; set; }
        }
    }
}
