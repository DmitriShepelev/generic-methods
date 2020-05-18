using GenericMethodsTask.Interfaces;
using GenericMethodsTask.Tests.Adaptee;
using Moq;
using NUnit.Framework;

namespace GenericMethodsTask.Tests.MoqTests
{
    [TestFixture]
    public class PredicateTests
    {
        private Mock<IPredicate<int>> mockPredicate;

        private IPredicate<int> predicate;

        [SetUp]
        public void Setup()
        {
            mockPredicate = new Mock<IPredicate<int>>();

            mockPredicate
                .Setup(p => p.Verify(It.Is<int>(i => new ContainsDigitPredicate() {Digit = 5}.Verify(i))))
                .Returns(true);

            predicate = mockPredicate.Object;
        }

        [TestCase(55)]
        [TestCase(551)]
        [TestCase(-12551)]
        [TestCase(-90551)]
        public void IsMatchTests_Return_True(int value)
        {
            Assert.IsTrue(predicate.Verify(value));

            mockPredicate.Verify(p => p.Verify(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestCase(109)]
        [TestCase(67632)]
        [TestCase(-120943)]
        [TestCase(-2113)]
        public void IsMatchTests_Return_False(int value)
        {
            Assert.IsFalse(predicate.Verify(value));

            mockPredicate.Verify(p => p.Verify(It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void FilterByTests()
        {
            var source = new int[] {12, 35, -65, 543, 23};

            var expected = new int[] {35, -65, 543};

            var actual = source.Filter(predicate);

            CollectionAssert.AreEqual(actual, expected);

            mockPredicate.Verify(p => p.Verify(It.IsAny<int>()), Times.Exactly(5));
        }
    }
}