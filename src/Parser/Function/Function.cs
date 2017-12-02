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
        public double Evaluate(Vector vec)
        {
            if (vec.Size != Variables.Length)
            {
                throw new ArgumentException("This function requires other number of variables");
            }

            Values values = new Values();

            for (int i = 0; i < vec.Size; i++)
            {
                values.Assign(Variables[i], vec[i]);
            }

            return expTree.Evaluate(values);
        }

        public string[] Variables { get; }

        private ExpNode expTree;
    }
}
