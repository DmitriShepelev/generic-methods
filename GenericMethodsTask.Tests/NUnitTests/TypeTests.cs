using System;
using NUnit.Framework;

#pragma warning disable CA1707
#pragma warning disable SA1313

namespace GenericMethodsTask.Tests.NUnitTests
{
    public class TypeTests
    {
        [TestCase(new object[] { 0, 15, 222, "abc", 27.3f, 'c', true, 567.001d, '\r', false, 84.25f, "qwerty", 0.001d }, default(int), ExpectedResult = new int[] { 0, 15, 222 })]
        [TestCase(new object[] { 0, 15, 222, "abc", 27.3f, 'c', true, 567.001d, '\r', false, 84.25f, "qwerty", 0.001d }, default(float), ExpectedResult = new float[] { 27.3f, 84.25f })]
        [TestCase(new object[] { 0, 15, 222, "abc", 27.3f, 'c', true, 567.001d, '\r', false, 84.25f, "qwerty", 0.001d }, default(double), ExpectedResult = new double[] { 567.001d, 0.001d })]
        [TestCase(new object[] { 0, 15, 222, "abc", 27.3f, 'c', true, 567.001d, '\r', false, 84.25f, "qwerty", 0.001d }, default(char), ExpectedResult = new char[] { 'c', '\r' })]
        [TestCase(new object[] { 0, 15, 222, "abc", 27.3f, 'c', true, 567.001d, '\r', false, 84.25f, "qwerty", 0.001d }, default(bool), ExpectedResult = new bool[] { true, false })]
        [TestCase(new object[] { 0, 15, 222, "abc", 27.3f, 'c', true, 567.001d, '\r', false, 84.25f, "qwerty", 0.001d }, "", ExpectedResult = new string[] { "abc", "qwerty" })]
        public T[] TypeOfTests_ReturnNewArray<T>(object[] source, T _) => ArrayExtension.TypeOf<T>(source);
    }
}
