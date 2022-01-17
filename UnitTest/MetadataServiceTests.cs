using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosoft.DataModel.Annotations;
using Ichosoft.DataModel.UnitTest.Resources;

namespace Ichosoft.DataModel.UnitTest
{
    [TestClass]
    public class MetadataServiceTests
    {
        private readonly IModelMetadataService metadataService = new ModelMetadataService();
        [TestMethod]
        public void GetAttributeFor_Class_WithoutMetadata_YieldsMatchingInstance()
        {
            var observed = metadataService.AttributeFor<NounAttribute>(typeof(ModelExample.Account));

            Assert.AreEqual(DataModelTestString.Account_Plural, observed.GetPlural());
            Assert.AreEqual(DataModelTestString.Account_PluralArticle, observed.GetPluralArticle());
            Assert.AreEqual(DataModelTestString.Account_Singular, observed.GetSingular());
            Assert.AreEqual(DataModelTestString.Account_SingularArticle, observed.GetSingularArticle());
        }

        [TestMethod]
        public void GetAttributeFor_Class_WithMetadata_YieldsMatchingInstance()
        {
            var observed = metadataService.AttributeFor<NounAttribute>(typeof(ModelMetadataExample.Account));

            Assert.AreEqual(DataModelTestString.Account_Plural, observed.GetPlural());
            Assert.AreEqual(DataModelTestString.Account_PluralArticle, observed.GetPluralArticle());
            Assert.AreEqual(DataModelTestString.Account_Singular, observed.GetSingular());
            Assert.AreEqual(DataModelTestString.Account_SingularArticle, observed.GetSingularArticle());
        }
    }
}
