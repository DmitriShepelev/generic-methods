using GenericMethodsTask.Interfaces;
using IEEE754FormatTask;

namespace Adapters
{
#pragma warning disable S101 // Types should be named in PascalCase
    public class GetIEEE754FormatAdapter : ITransformer<double, string>
#pragma warning restore S101 // Types should be named in PascalCase
    {     
        public string Transform(double obj)
        {
            return DoubleExtension.GetIEEE754Format(obj);
        }
    }
}
