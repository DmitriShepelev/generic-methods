using System;
using Adapters;
using NUnit.Framework;

#pragma warning disable CA1707
#pragma warning disable SA1118

namespace GenericMethodsTask.Tests.NUnitTests
{
    [TestFixture]
    public class TransformerTests
    {
        [Test]
        public void Transform_ArrayIsNull_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(
            () => ArrayExtension.Transform(null, new Adapters.GetIEEE754FormatAdapter()),
            "Array cannot be null.");

        [Test]
        public void TransformTest_ArrayIsEmpty_ThrowArgumentException() => Assert.Throws<ArgumentException>(
            () => ArrayExtension.Transform(Array.Empty<double>(), new Adapters.GetIEEE754FormatAdapter()),
            "Array cannot be empty.");

        [TestCase(122.625, "0100000001011110101010000000000000000000000000000000000000000000")]
        [TestCase(-255.255, "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(-451387.2345, "1100000100011011100011001110110011110000001000001100010010011100")]
        [TestCase(double.NegativeInfinity, "1111111111110000000000000000000000000000000000000000000000000000")]
        public void TransformerTest_Adapter_ReturnExpectedValue(double value, string expected)
        {
            var transformer = new GetIEEE754FormatAdapter();
            Assert.AreEqual(expected, transformer.Transform(value));
        }

        [TestCase(
            new[]
            {
                double.PositiveInfinity, 0.0, double.NegativeInfinity, -0.0, double.Epsilon, double.NaN,
            },
            ExpectedResult = new[]
            {
                "0111111111110000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "1111111111110000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000001",
                "1111111111111000000000000000000000000000000000000000000000000000",
            })]
        public string[] TransformTests(double[] source) =>
            ArrayExtension.Transform(source, new Adapters.GetIEEE754FormatAdapter());
    }
}
