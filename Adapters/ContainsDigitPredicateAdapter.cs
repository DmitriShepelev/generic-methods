using ContainsDigitPredicate;
using GenericMethodsTask.Interfaces;

namespace Adapters
{
    public class ContainsDigitPredicateAdapter : IPredicate<int>
    {
        private readonly ContainsDigitValidator adapter;

        public ContainsDigitPredicateAdapter(ContainsDigitValidator validator)
        {
            this.adapter = validator;
        }
        
        public bool Verify(int obj)
        {
            return this.adapter.Verify(obj);
        }
    }
}
