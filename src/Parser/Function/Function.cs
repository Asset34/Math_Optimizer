using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Func.Tree;

namespace MathOptimizer.Parser.Func
{
    class Function
    {
        public Function(ExpNode expTree, string[] variables)
        {
            this.expTree = expTree;
            Variables = variables;
        }
        public double Evaluate(Values values)
        {
            return expTree.Evaluate(values);
        }

        public string[] Variables { get; }

        private ExpNode expTree;
    }
}
