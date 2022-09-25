using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosys.DataModel.Annotations;
using Ichosys.DataModel.Tests.Resources;
using Ichosys.DataModel.Tests.ModelExample;

namespace Ichosys.DataModel.Tests.Unit
{
    [TestClass]
    public class MetadataServiceTests
    {
        private readonly IModelMetadataService metadataService = new ModelMetadataService();
        [TestMethod]
        public void GetAttributeFor_Class_WithoutMetadata_YieldsMatchingInstance()
        {
            NounAttribute observed = metadataService.GetAttribute<Account, NounAttribute>();

            Assert.AreEqual(DataModelTestString.Account_Plural, observed.GetPlural());
            Assert.AreEqual(DataModelTestString.Account_PluralArticle, observed.GetPluralArticle());
            Assert.AreEqual(DataModelTestString.Account_Singular, observed.GetSingular());
            Assert.AreEqual(DataModelTestString.Account_SingularArticle, observed.GetSingularArticle());
        }

        [TestMethod]
        public void GetAttributeFor_Class_WithMetadata_YieldsMatchingInstance()
        {
            NounAttribute observed = metadataService.GetAttribute<Account, NounAttribute>();

            Assert.AreEqual(DataModelTestString.Account_Plural, observed.GetPlural());
            Assert.AreEqual(DataModelTestString.Account_PluralArticle, observed.GetPluralArticle());
            Assert.AreEqual(DataModelTestString.Account_Singular, observed.GetSingular());
            Assert.AreEqual(DataModelTestString.Account_SingularArticle, observed.GetSingularArticle());
        }

        [TestMethod]
        public void DescriptionFor_Generic_ReturnsExpectedString()
        {
            var observed = metadataService.DescriptionFor<Account>(x => x.AccountNumber);

            Assert.IsNotNull(observed);
            Assert.AreEqual(DataModelTestString.Display_AccountNumber_Description, observed);
        }

        [TestMethod]
        public void GroupNameFor_Generic_ReturnsExpectedString()
        {
            var observed = metadataService.GroupNameFor<Account>(x => x.AccountNumber);

            Assert.IsNotNull(observed);
            Assert.AreEqual(DataModelTestString.Display_AccountNumber_GroupName, observed);
        }

        [TestMethod]
        public void NameFor_Generic_ReturnsExpectedString()
        {
            var observed = metadataService.NameFor<Account>(x => x.AccountNumber);

            Assert.IsNotNull(observed);
            Assert.AreEqual(DataModelTestString.Display_AccountNumber_Name, observed);
        }

        [TestMethod]
        public void OrderFor_Generic_ReturnsExpectedString()
        {
            int? observed = metadataService.OrderFor<Account>(x => x.AccountNumber);

            Assert.IsNotNull(observed);
            Assert.AreEqual(default(int), observed);
        }

        [TestMethod]
        public void PromptFor_Generic_ReturnsExpectedString()
        {
            var observed = metadataService.PromptFor<Account>(x => x.AccountNumber);

            Assert.IsNotNull(observed);
            Assert.AreEqual(DataModelTestString.Display_AccountNumber_Prompt, observed);
        }

        [TestMethod]
        public void ShortNameFor_Generic_ReturnsExpectedString()
        {
            var observed = metadataService.ShortNameFor<Account>(x => x.AccountNumber);

            Assert.IsNotNull(observed);
            Assert.AreEqual(DataModelTestString.Display_AccountNumber_ShortName, observed);
        }
    }
}
