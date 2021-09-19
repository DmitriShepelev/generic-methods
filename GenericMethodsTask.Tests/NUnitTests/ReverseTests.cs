using System;
using NUnit.Framework;

#pragma warning disable CA1707

namespace GenericMethodsTask.Tests.NUnitTests
{
    [TestFixture(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, TypeArgs = new Type[] { typeof(int) })]
    [TestFixture(new[] { "a", "b", "c", "d" }, new[] { "d", "c", "b", "a" }, TypeArgs = new Type[] { typeof(string) })]
    public class ReverseTests<T>
    {
        private readonly T[] source;
        private readonly T[] expected;

        public ReverseTests(T[] source, T[] expected)
        {
            this.source = source;
            this.expected = expected;
        }

        [Test]
        public void ReverseTest() => CollectionAssert.AreEqual(this.expected, this.source.Reverse());

        [Test]
        public void ReverseTest_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => ArrayExtension.Reverse(Array.Empty<int>()), "Array cannot be empty");

        [Test]
        public void ReverseTest_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.Reverse<T>(null), "Array cannot be null");
    }
}
