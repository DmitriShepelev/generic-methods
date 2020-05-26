using System;
using System.Collections.Generic;

namespace GenericMethodsTask.Tests.Comparers
{
    public class StringByLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y) => throw new NotImplementedException();
    }
}