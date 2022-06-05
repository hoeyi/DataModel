using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosys.DataModel.Annotations;
using Ichosys.DataModel.UnitTest.Resources;

namespace Ichosys.DataModel.UnitTest.TestAnnotations
{
    [TestClass]
    public class NounAttributeTests
    {
        [TestMethod]
        public void NounAttribute_OnClass_WithoutMetadata_ValidResourceKeys_YieldsExpectedStrings()
        {
            NounAttribute nounAttribute = typeof(ModelExample.Account).GetAttribute<NounAttribute>();

            Assert.AreEqual(DataModelTestString.Account_Plural, nounAttribute?.GetPlural());
            Assert.AreEqual(DataModelTestString.Account_PluralArticle, nounAttribute?.GetPluralArticle());
            Assert.AreEqual(DataModelTestString.Account_Singular, nounAttribute?.GetSingular());
            Assert.AreEqual(DataModelTestString.Account_SingularArticle, nounAttribute?.GetSingularArticle());
        }

        [TestMethod]
        public void NounAttribute_OnProperty_WithoutMetadata_ValidResourceKeys_YieldsExpectedStrings()
        {
            NounAttribute nounAttribute = typeof(ModelExample.Account)
                .GetProperty(nameof(ModelExample.Account.AccountNumber))
                ?.GetAttribute<NounAttribute>();

            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_Plural, nounAttribute?.GetPlural());
            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_PluralArticle, nounAttribute?.GetPluralArticle());
            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_Singular, nounAttribute?.GetSingular());
            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_SingularArticle, nounAttribute?.GetSingularArticle());
        }


        [TestMethod]
        public void NounAttribute_OnClass_WithMetadata_ValidResourceKeys_YieldsExpectedStrings()
        {
            NounAttribute nounAttribute = typeof(ModelMetadataExample.Account).GetAttribute<NounAttribute>();

            Assert.AreEqual(DataModelTestString.Account_Plural, nounAttribute?.GetPlural());
            Assert.AreEqual(DataModelTestString.Account_PluralArticle, nounAttribute?.GetPluralArticle());
            Assert.AreEqual(DataModelTestString.Account_Singular, nounAttribute?.GetSingular());
            Assert.AreEqual(DataModelTestString.Account_SingularArticle, nounAttribute?.GetSingularArticle());
        }

        [TestMethod]
        public void NounAttribute_OnProperty_WithMetadata_ValidResourceKeys_YieldsExpectedStrings()
        {
            NounAttribute nounAttribute = typeof(ModelMetadataExample.Account)
                .GetProperty(nameof(ModelMetadataExample.Account.AccountNumber))
                ?.GetAttribute<NounAttribute>();

            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_Plural, nounAttribute?.GetPlural());
            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_PluralArticle, nounAttribute?.GetPluralArticle());
            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_Singular, nounAttribute?.GetSingular());
            Assert.AreEqual(
                DataModelTestString.Account_AccountNumber_SingularArticle, nounAttribute?.GetSingularArticle());
        }
    }
}
