using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using Ichosoft.DataModel.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosoft.DataModel.Annotations;

namespace Ichosoft.DataModel.UnitTest
{
    [TestClass]
    public class ExpressionBuilderTests
    {
        [TestMethod]
        public void GetComparisonOperators_ReturnsExpectedList()
        {
            var expBuilder = new ExpressionBuilder();
            var res = expBuilder.GetComparisonOperators();

            var rm = new ResourceManager(typeof(DataModel.Resources.ComparisonOperatorString));
            string observed;
            string expected;
            
            var type = typeof(ComparisonOperator);
            foreach(var r in res)
            {
                observed = type.GetMember(memberName: $"{r}")?.GetAttribute<DisplayAttribute>()?.GetName();
                expected = rm.GetString($"{r}");
                Shared.WriteAreEqualDebug(expected, observed);
                Assert.AreEqual(expected, observed);
            }
        }

        [TestMethod]
        public void GetSearchableMembers_ClassWithoutMetadata_ReturnsExpectedList()
        {
            var expBuilder = new ExpressionBuilder();
            var res = expBuilder.GetSearchableMembers<ModelExample.Account>();

            SearchableMemberMetadata[] expectedArray = new SearchableMemberMetadata[]
            {
                new()
                {
                    Display = typeof(ModelExample.Account).GetProperty(nameof(ModelExample.Account.AccountNumber))
                        .GetCustomAttribute<DisplayAttribute>(),
                    QualifiedMemberName = nameof(ModelExample.Account.AccountNumber)
                },
                new()
                {
                    Display = typeof(ModelExample.AccountObject)
                        .GetProperty(nameof(ModelExample.AccountObject.AccountObjectCode))
                        .GetCustomAttribute<DisplayAttribute>(),
                    QualifiedMemberName = $"{nameof(ModelExample.Account.AccountNavigation)}" +
                        $".{nameof(ModelExample.AccountObject.AccountObjectCode)}"
                }
            };

            Assert.IsInstanceOfType(res, typeof(IEnumerable<ISearchableMemberMetadata>));

            bool basePropertyReturned = res.Contains(expectedArray[0]);
            bool nestedPropertyReturned = res.Contains(expectedArray[1]);

            Debug.WriteLine(string.Format("Base property check: {0}", basePropertyReturned ? "PASSED" : "FAILED"));
            Debug.WriteLine(string.Format("Nested property check: {0}", basePropertyReturned ? "PASSED" : "FAILED"));

            string observed = expectedArray[0].Display?.GetName();
            string expected = Resources.DataModelTestString.Account_AccountNumber;
            Shared.WriteAreEqualDebug(expected, observed);
            Assert.AreEqual(expected, observed);

            observed = expectedArray[1].Display?.GetName();
            expected = Resources.DataModelTestString.AccountObject_AccountObjectCode;
            Shared.WriteAreEqualDebug(expected, observed);
            Assert.AreEqual(expected, observed);

            Assert.IsTrue(basePropertyReturned && nestedPropertyReturned);
        }

        [TestMethod]
        public void GetSearchableMembers_ClassWithMetadata_ReturnsExpectedList()
        {
            var expBuilder = new ExpressionBuilder();
            var res = expBuilder.GetSearchableMembers<ModelMetadataExample.Account>();

            SearchableMemberMetadata[] expectedArray = new SearchableMemberMetadata[]
            {
                new()
                {
                    Display = typeof(ModelMetadataExample.AccountMetadata)
                        .GetProperty(nameof(ModelMetadataExample.AccountMetadata.AccountNumber))
                        .GetCustomAttribute<DisplayAttribute>(),
                    QualifiedMemberName = nameof(ModelMetadataExample.Account.AccountNumber)
                },
                new()
                {
                    Display = typeof(ModelMetadataExample.AccountObjectMetadata)
                        .GetProperty(nameof(ModelMetadataExample.AccountObjectMetadata.AccountObjectCode))
                        .GetCustomAttribute<DisplayAttribute>(),
                    QualifiedMemberName = $"{nameof(ModelMetadataExample.Account.AccountNavigation)}" +
                        $".{nameof(ModelMetadataExample.AccountObject.AccountObjectCode)}"
                }
            };

            Assert.IsInstanceOfType(res, typeof(IEnumerable<ISearchableMemberMetadata>));

            bool basePropertyReturned = res.Contains(expectedArray[0]);
            bool nestedPropertyReturned = res.Contains(expectedArray[1]);

            Debug.WriteLine(string.Format("Base property check: {0}", basePropertyReturned ? "PASSED" : "FAILED"));
            Debug.WriteLine(string.Format("Nested property check: {0}", basePropertyReturned ? "PASSED" : "FAILED"));

            string observed = expectedArray[0].Display?.GetName();
            string expected = Resources.DataModelTestString.Account_AccountNumber;
            Shared.WriteAreEqualDebug(expected, observed);
            Assert.AreEqual(expected, observed);

            observed = expectedArray[1].Display?.GetName();
            expected = Resources.DataModelTestString.AccountObject_AccountObjectCode;
            Shared.WriteAreEqualDebug(expected, observed);
            Assert.AreEqual(expected, observed);

            Assert.IsTrue(basePropertyReturned && nestedPropertyReturned);
        }

        [TestMethod]
        public void GetExpression_Account_AccountObjectCode_EqualsString_YieldsExpression()
        {
            var expBuilder = new ExpressionBuilder();
            var queryParameter = new QueryParameter<ModelExample.Account>(
                memberName: $"{nameof(ModelExample.Account.AccountNavigation)}.{nameof(ModelExample.AccountObject.AccountObjectCode)}",
                @operator: ComparisonOperator.EqualTo,
                paramValue: "Test");

            Expression<Func<ModelExample.Account, bool>> observed = expBuilder.GetExpression(queryParameter);

            IQueryable<ModelExample.Account> testAccounts = new List<ModelExample.Account>()
            {
                new()
                {
                    AccountId = 0,
                    AccountNavigation = new(){ AccountObjectCode = "A"}
                },
                new()
                {
                    AccountId = 1,
                    AccountNavigation = new(){ AccountObjectCode = "Test"}
                },
            }.AsQueryable();

            var exp = testAccounts.FirstOrDefault(observed);

            Assert.AreEqual(1, exp.AccountId);
        }
    }
}
