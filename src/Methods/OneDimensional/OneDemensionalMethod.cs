using MathOptimizer.Parser.Func;
using MathOptimizer.Methods.Params;

namespace MathOptimizer.Methods.OneDimensional
{
    abstract class OneDimensionalMethod
    {
        public abstract void run(Function f, ref Parameters parameters);
    }
}
