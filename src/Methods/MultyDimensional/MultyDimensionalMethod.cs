using MathOptimizer.Func;
using MathOptimizer.Methods.Params;
using MathOptimizer.Methods.OneDimensional;

namespace MathOptimizer.Methods.MultyDimensional
{
    //
    // Summary:
    //     Represents base abstract class for multy-dimensional methods 
    abstract class MultyDimensionalMethod
    {
        public abstract void run(Function f, OneDimensionalMethod method, ref Parameters parameters);
    }
}
