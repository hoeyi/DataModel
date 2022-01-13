using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosoft.Expressions.UnitTest.ModelExample;

namespace Ichosoft.Expressions.UnitTest
{
    [TestClass]
    public class ExpressionBuilderTests
    {
        [TestMethod]
        public void GetSearchableMembers_ClassWithComplexProperty_ReturnsExpectedList()
        {
            var expBuilder = new ExpressionBuilder();
            var res = expBuilder.GetSearchableMembers<Account>();

            SearchableMemberMetadata[] expected = new SearchableMemberMetadata[]
            {
                new()
                {
                    Display = typeof(Account).GetProperty(nameof(Account.AccountNumber))
                        .GetCustomAttribute<DisplayAttribute>(),
                    QualifiedMemberName = nameof(Account.AccountNumber)
                },
                new()
                {
                    Display = typeof(AccountObject).GetProperty(nameof(AccountObject.AccountObjectCode))
                        .GetCustomAttribute<DisplayAttribute>(),
                    QualifiedMemberName = $"{nameof(Account.AccountNavigation)}.{nameof(AccountObject.AccountObjectCode)}"
                }
            };

            Assert.IsInstanceOfType(res, typeof(IEnumerable<ISearchableMemberMetadata>));

            bool basePropertyReturned = res.Contains(expected[0]);
            bool nestedPropertyReturned = res.Contains(expected[1]);

            Debug.WriteLine(string.Format("Base property check: {0}", basePropertyReturned ? "PASSED" : "FAILED"));
            Debug.WriteLine(string.Format("Nested property check: {0}", basePropertyReturned ? "PASSED" : "FAILED"));

            Assert.IsTrue(basePropertyReturned && nestedPropertyReturned);
        }

        [TestMethod]
        public void GetExpression_Account_AccountObjectCode_EqualsString_YieldsExpression()
        {
            var expBuilder = new ExpressionBuilder();
            var queryParameter = new QueryParameter<Account>(
                memberName: $"{nameof(Account.AccountNavigation)}.{nameof(AccountObject.AccountObjectCode)}",
                @operator: ComparisonOperator.EqualTo,
                paramValue: "Test");

            Expression<Func<Account,bool>> observed = expBuilder.GetExpression(queryParameter);

            IQueryable<Account> testAccounts = new List<Account>()
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
