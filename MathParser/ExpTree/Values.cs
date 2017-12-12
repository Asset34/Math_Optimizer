using System.Collections.Generic;

namespace MathOptimizer.Parser.ExpTree
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
