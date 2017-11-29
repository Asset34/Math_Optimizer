using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Function.Tree;

namespace MathOptimizer.Parser.Function
{
    class Values
    {
        public double GetValue(string name)
        {
            return variables[name];
        }
        public void Assign(VariableExp variable, double value)
        {
            variables.Add(variable.Name, value);
        }

        private Dictionary<string, double> variables = new Dictionary<string, double>();
    }
}
