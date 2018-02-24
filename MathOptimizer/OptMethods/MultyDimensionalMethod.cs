using MathOptimizer.Entities;
using MathOptimizer.Methods.Params;

namespace MathOptimizer.Methods.MultyDimensional
{
    /// <summary>
    /// Base class for multidimensional methods
    /// </summary>
    abstract class MultyDimMethod
    {
        public abstract void run(Function f, Parameters parameters);
    }
}
