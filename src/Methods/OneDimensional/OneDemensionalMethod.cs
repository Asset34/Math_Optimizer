using MathOptimizer.Func;
using MathOptimizer.Methods.Params;

namespace MathOptimizer.Methods.OneDimensional
{
    //
    // Summary:
    //     Represents base abstract class for one-demensional methods 
    abstract class OneDimensionalMethod
    {
        public abstract void run(Function f, ref Parameters parameters);
    }
}
