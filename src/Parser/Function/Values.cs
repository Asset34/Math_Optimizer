using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Func.Tree;

namespace MathOptimizer.Parser.Func
{
    class Values
    {
        public double GetValue(string name)
        {
            return variables[name];
        }
        public void Assign(string name, double value)
        {
            variables.Add(name, value);
        }

        private Dictionary<string, double> variables = new Dictionary<string, double>();
    }
}
