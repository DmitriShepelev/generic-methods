using System;

namespace GenericMethodsTask.Tests.Adaptee
{
    //Note: This class should not implement any interfaces
    //Put your code from class ContainsDigitPredicate see 
    // https://gitlab.com/epam-autocode-tasks/filter-strategy/-/blob/master/FilterStrategyTask.Tests/PredicateImplementations/ContainsDigitPredicate.cs
    internal class ContainsDigitPredicate
    {
        //TODO: Add code here if necessary or delete this comment.
        
        public int Digit
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        
        public bool Verify(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}