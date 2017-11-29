using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser.Func.Tree
{
    abstract class ExpNode
    {
        public abstract double Evaluate(Values values);
    }
}
