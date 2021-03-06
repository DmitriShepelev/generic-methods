using System;
using System.Collections.Generic;

namespace Comparers
{
    public class StringByLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x is null && y is null)
            {
                return 0;
            }

            if (x is null)
            {
                return -1;
            }

            if (y is null)
            {
                return 1;
            }      
            
            return x.Length.CompareTo(y.Length);
        }
    }
}
