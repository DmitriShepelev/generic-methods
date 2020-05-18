using GenericMethodsTask.Interfaces;

namespace GenericMethodsTask.Tests.Predicates
{
    public class OddPredicate : IPredicate<int>
    {
        public bool Verify(int value) => value % 2 != 0;
    }
}