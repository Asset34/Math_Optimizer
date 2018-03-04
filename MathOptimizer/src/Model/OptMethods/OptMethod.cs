using MathOptimizer.Model.Entities;
using MathOptimizer.Model.Methods.Params;

namespace MathOptimizer.Model.Methods.MultyDimensional
{
    /// <summary>
    /// Base class for optimization methods
    /// </summary>
    abstract class OptMethod
    {
        public abstract void run(Function f, Parameters parameters);
    }
}
