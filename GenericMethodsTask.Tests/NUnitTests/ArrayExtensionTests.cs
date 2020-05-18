using System;
using System.Collections.Generic;
using GenericMethodsTask.Interfaces;
using GenericMethodsTask.Tests.Adapters;
using NUnit.Framework;

namespace GenericMethodsTask.Tests.NUnitTests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        private static IEnumerable<TestCaseData> Predicates => throw new NotImplementedException();

        private static IEnumerable<TestCaseData> Transformers
        {
            get
            {
                yield return new TestCaseData(
                        new GetIEEE754FormatAdapter(),
                        new [] {-255.255, 255.255, 4294967295.0, double.Epsilon, double.NaN, double.MinValue})
                    .Returns(new []
                    {
                        "1100000001101111111010000010100011110101110000101000111101011100",
                        "0100000001101111111010000010100011110101110000101000111101011100",
                        "0100000111101111111111111111111111111111111000000000000000000000",
                        "0000000000000000000000000000000000000000000000000000000000000001",
                        "1111111111111000000000000000000000000000000000000000000000000000",
                        "1111111111101111111111111111111111111111111111111111111111111111"
                    });
                yield return new TestCaseData(new GetIEEE754FormatAdapter(),
                        new double[] {double.PositiveInfinity, 0.0, double.NegativeInfinity, -0.0})
                    .Returns(new[]
                    {
                        "0111111111110000000000000000000000000000000000000000000000000000",
                        "0000000000000000000000000000000000000000000000000000000000000000",
                        "1111111111110000000000000000000000000000000000000000000000000000",
                        "1000000000000000000000000000000000000000000000000000000000000000"
                    });
                //TODO: Add new test case data with new logic for double transformation.
                // see https://autocode.lab.epam.com/course-manager/task/229
            }
        }

        [TestCaseSource(nameof(Transformers))]
        public string[] FilterByTests(ITransformer<double, string> transformer, double[] source)
        {
            return source.Transform(transformer);
        }
        
        //TODO: Add new test cases for transformation 
        //TODO: Add test methods for filter.
    }
}