using System;
using Comparers;
using NUnit.Framework;

namespace GenericMethodsTask.Tests.NUnitTests
{
    internal static class ComparerTests
    {
        [Test]
        public static void SortBy_ArrayIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.SortBy<int>(null, new IntegerByAbsComparer()), "Array can not be null.");

        [Test]
        public static void SortBy_ArrayIsEmpty_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => ArrayExtension.SortBy<int>(Array.Empty<int>(), new IntegerByAbsComparer()), "Array can not be empty.");

        [Test]
        public static void SortBy_ComparerIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.SortBy<int>(new[] { 1, 3, 4 }, null), "Comparer can not be null.");

        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 1 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2, 3, 1 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1, 3, 2, 1, 3, 2, 1 }, ExpectedResult = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 })]
        [TestCase(new int[] { 1, 6, 2, 6, 3, 6, 4, 6, 5, 6, 7, 6 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7 })]
        [TestCase(new int[] { 7, 6, 5, 4, 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0 }, ExpectedResult = new int[] { 0, -1, 1, -2, 2, -3, 3, 4, -4, 5, -5, 6, -6, 7, -7, 8, -8, -9, 9, 10, -10 })]
        [TestCase(new[] { 0, 12, -12, 34, 0, 2, -567, 12, -12, 89, int.MaxValue, -1000 }, ExpectedResult = new[] { 0, 0, 2, 12, -12, 12, -12, 34, 89, -567, -1000, int.MaxValue })]
        public static int[] SortBy_ReturnsSortedArray(int[] array) => ArrayExtension.SortBy<int>(array, new IntegerByAbsComparer());

        [Test]
        public static void SortBy_ReturnsSortedArray()
        {
            var source = new[] { "Abc", null, "abcd", "aa", "a", "A", "a", null, "ab", string.Empty };
            var expected = new[] { null, null, string.Empty, "a", "A", "a", "aa", "ab", "Abc", "abcd" };
            Assert.AreEqual(expected, ArrayExtension.SortBy(source, new StringByLengthComparer()));
        }
    }
}
