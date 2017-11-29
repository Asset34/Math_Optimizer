using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser.Function.Tree
{
    class VariableExp : ExpNode
    {
        public VariableExp(string name)
        {
            this.Name = name;
        }
        public override double Evaluate(Values values)
        {
            return values.GetValue(Name);
        }

        public string Name { get; }
    }
    class NumberExp : ExpNode
    {
        public NumberExp(double number)
        {
            this.number = number;
        }
        public override double Evaluate(Values values)
        {
            return number;
        }

        private double number;
    }
}
