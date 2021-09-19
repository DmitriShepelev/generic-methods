using System;
using System.Collections.Generic;

namespace Comparers
{
    public class IntegerByAbsComparer : IComparer<int>
    {
        public int Compare(int x, int y) => Math.Abs(x).CompareTo(Math.Abs(y));
    }
}
