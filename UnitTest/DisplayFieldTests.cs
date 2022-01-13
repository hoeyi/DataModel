using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ichosoft.Expressions.Annotations;
using Ichosoft.Expressions.UnitTest.Resources;

namespace Ichosoft.Expressions.UnitTest
{
    [TestClass]
    public class DisplayFieldTests
    {
        [TestMethod]
        public void Property_DecoratedWithDisplayField_YieldsExpectedString()
        {
            var displayField = typeof(TestClass1).GetProperty(nameof(TestClass1.TestProperty))
                .GetCustomAttribute<DisplayField>();

            string observed = displayField?.Text;
            string expected = TestStrings.TestClass1_TestProperty;

            Assert.AreEqual(expected, observed);
        }

        [TestMethod]
        public void Property_InClassWithMetadata_DecoratedWithDisplayField_YieldsExpectedString()
        {
            var displayField = typeof(TestClass_WithMetadata).GetProperty(nameof(TestClass_WithMetadata.TestProperty))
                .GetCustomAttribute<DisplayField>();

            string observed = displayField?.Text;
            string expected = TestStrings.TestClass_WithMetadata_TestProperty;

            Assert.AreEqual(expected, observed);
        }


        class TestClass1
        {
            [DisplayField(typeof(TestStrings), nameof(TestClass1), nameof(TestProperty))]
            public string TestProperty { get; set; }
        }


        partial class TestClass_WithMetadata
        {
            public string TestProperty { get; set; }
        }

        [MetadataType(typeof(TestClassMetadata))]
        partial class TestClass_WithMetadata
        {
        }
        partial class TestClassMetadata
        {
            [DisplayField(typeof(TestStrings), nameof(TestClass_WithMetadata), nameof(TestProperty))]
            public string TestProperty { get; set; }
        }
    }
}
