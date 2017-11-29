using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser.Function
{
    abstract class ExpTree
    {
        public abstract double Evaluate(Values values);
    }
}
