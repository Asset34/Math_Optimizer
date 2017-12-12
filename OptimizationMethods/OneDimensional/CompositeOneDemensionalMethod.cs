using System.Collections.Generic;

using MathOptimizer;
using MathOptimizer.Methods.Params;

namespace MathOptimizer.Methods.OneDimensional
{
    class CompositeOneDimensionalMethod : OneDimensionalMethod
    {
        public CompositeOneDimensionalMethod()
        {
            Methods = new List<OneDimensionalMethod>();
        }
        public override void run(Function f, ref Parameters parameters)
        {
            foreach (OneDimensionalMethod method in Methods)
            {
                method.run(f, ref parameters);
                parameters.SwapParameters();
            }
        }

        public List<OneDimensionalMethod> Methods { get; set; }
    }
}
