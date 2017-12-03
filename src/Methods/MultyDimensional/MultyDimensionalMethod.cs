using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Func;
using MathOptimizer.Methods.Params;
using MathOptimizer.Methods.OneDimensional;

namespace MathOptimizer.Methods.MultyDimensional
{
    abstract class MultyDimensionalMethod
    {
        public abstract void run(Function f, OneDimensionalMethod method, ref Parameters parameters);
    }
}
