using Ichosys.DataModel.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace Ichosys.DataModel.Tests.Integration
{
    [TestClass]
    public class ExactValueAttributeTests
    {
        [TestMethod]
        public void IntegerValue_CorrectValue_YieldsValidatedModel()
        {
            var example = new ExampleWithInteger() { IntegerValue = 1 };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IntegerValue_IncorrectValue_YieldsInvalidatedModel()
        {
            var example = new ExampleWithInteger() { IntegerValue = 2 };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void DoubleValue_CorrectValue_YieldsValidatedModel()
        {
            var example = new ExampleWithDouble() { DoubleValue = 1.5D };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void DoubleValue_IncorrectValue_YieldsInvalidatedModel()
        {
            var example = new ExampleWithDouble() { DoubleValue = 2.5D };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void BooleanValue_CorrectValue_YieldsValidatedModel()
        {
            var example = new ExampleWithBoolean() { BoolValue = true };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void BooleanValue_IncorrectValue_YieldsInvalidatedModel()
        {
            var example = new ExampleWithBoolean() { BoolValue = false };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void MultipleValues_AllCorrect_YieldsValidatedModel()
        {
            var example = new ExampleWithAll()
            {
                IntegerValue = 1,
                DoubleValue = 1.5D,
                BoolValue = true
            };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void MultipleValue_PartialCorrect_YieldsInvalidatedModel()
        {
            var example = new ExampleWithAll()
            {
                IntegerValue = 1,
                DoubleValue = 1.5D,
                BoolValue = false
            };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void MultipleValue_AllIncorrect_YieldsInvalidatedModel()
        {
            var example = new ExampleWithAll()
            {
                IntegerValue = 2,
                DoubleValue = 2.5D,
                BoolValue = false
            };

            var context = new ValidationContext(example, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(example, context, validationResults, true);

            if (!isValid)
                Shared.Logger.LogInformation("Valdiation failed. {Results}", validationResults);

            Assert.IsFalse(isValid);
            Assert.AreEqual(3, validationResults.Count);
        }

        class ExampleWithInteger
        {
            [ExactValue(1)]
            public int IntegerValue { get; set; }
        }

        class ExampleWithDouble
        {
            [ExactValue(1.5D)]
            public double DoubleValue { get; set; }
        }

        class ExampleWithBoolean
        {
            [ExactValue(true)]
            public bool BoolValue { get; set; }
        }

        class ExampleWithAll
        {
            [ExactValue(1)]
            public int IntegerValue { get; set; }

            [ExactValue(1.5D)]
            public double DoubleValue { get; set; }

            [ExactValue(true)]
            public bool BoolValue { get; set; }
        }
    }
}
