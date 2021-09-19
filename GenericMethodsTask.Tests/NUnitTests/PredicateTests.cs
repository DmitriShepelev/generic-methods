using System;
using Adapters;
using Comparers;
using ContainsDigitPredicate;
using NUnit.Framework;

#pragma warning disable CA1707

namespace GenericMethodsTask.Tests.NUnitTests
{
    [TestFixture]
    public class PredicateTests
    {
        [Test]
        public void FilterTest_ArrayIsEmpty_ThrowArgumentException() =>
               Assert.Throws<ArgumentException>(
                   () => ArrayExtension.Filter(Array.Empty<int>(), new ContainsDigitPredicateAdapter(new ContainsDigitValidator { Digit = 5 })), "Array can not be empty.");

        [Test]
        public void FilterTest_ArrayIsNull_ThrowArgumentNullException() =>
               Assert.Throws<ArgumentNullException>(
                   () => ArrayExtension.Filter(null, new ContainsDigitPredicateAdapter(new ContainsDigitValidator { Digit = 5 })), "Array can not be null.");

        [Test]
        public void FilterTest_PredicateIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.Filter(new[] { 0, 1, 2, 3, 4 }, null), "Predicate can not be null.");
        }

        [Test]
        public void VerifyPredicateTest_DigitLessZero_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ContainsDigitPredicateAdapter(new ContainsDigitValidator { Digit = -2 }), "Expected digit can not be less than zero.");

        [Test]
        public void VerifyPredicateTest_DigitMoreThanNine_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ContainsDigitPredicateAdapter(new ContainsDigitValidator { Digit = 15 }), "Expected digit can not be more than nine.");

        [TestCase(55)]
        [TestCase(551)]
        [TestCase(-12551)]
        [TestCase(-90551)]
        public void VerifyPredicateTests_Return_True(int value)
        {
            var adapter = new ContainsDigitPredicateAdapter(new ContainsDigitValidator { Digit = 5 });
            Assert.IsTrue(adapter.Verify(value));
        }

        [TestCase(109)]
        [TestCase(67632)]
        [TestCase(-120943)]
        [TestCase(-2113)]
        public void VerifyPredicateTests_Return_False(int value)
        {
            var adapter = new ContainsDigitPredicateAdapter(new ContainsDigitValidator { Digit = 5 });
            Assert.IsFalse(adapter.Verify(value));
        }

        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new[] { -123, 123, 2202, 3333, 4444, 55055, 0, -7, 5402, 9, 0, -150, 287 }, 0, ExpectedResult = new int[] { 2202, 55055, 0, 5402, 0, -150 })]
        [TestCase(new[] { -123, 123, 2202, 3333, 4444, 55055, 0, -7, 5402, 9, 0, -150, 287 }, 2, ExpectedResult = new int[] { -123, 123, 2202, 5402, 287 })]
        [TestCase(new[] { -583, -7481, -24, -81001, -32, -10805 }, 8, ExpectedResult = new[] { -583, -7481, -81001, -10805 })]
        [TestCase(new[] { 111, 111, 111, 11111111 }, 1, ExpectedResult = new[] { 111, 111, 111, 11111111 })]
        [TestCase(new[] { 111, 111, 111, 11111111 }, 5, ExpectedResult = new int[0])]
        [TestCase(new[] { -1, 0, 111, -11, -1 }, 1, ExpectedResult = new int[] { -1, 111, -11, -1 })]
        [TestCase(new[] { 0, 0, 0, 0, 0 }, 5, ExpectedResult = new int[0] { })]
        [TestCase(new[] { 0, 0, 0, 0, 0 }, 0, ExpectedResult = new int[] { 0, 0, 0, 0, 0 })]
        public int[] FilterTest_WithCorrectDigits_ReturnNewArray(int[] array, int digit) =>
            ArrayExtension.Filter(array, new ContainsDigitPredicateAdapter(new ContainsDigitValidator { Digit = digit }));
    }
}
