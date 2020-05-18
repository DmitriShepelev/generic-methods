using GenericMethodsTask.Interfaces;

namespace GenericMethodsTask.Tests.Predicates
{
    internal class OddPredicate : IPredicate<int>
    {
        public bool Verify(int value) => value % 2 != 0;
    }
}