using System.Collections.Generic;

namespace MathOptimizer.Parser.ExpTree
{
    /// <summary>
    /// Class which links values to variables
    /// </summary>
    class Values
    {
        public double GetValue(string name)
        {
            return variables[name];
        }
        /// <summary>
        /// Assign specific value to the variable
        /// </summary>
        /// <param name="name"> name of the variable </param>
        /// <param name="value"> specific value </param>
        public void Assign(string name, double value)
        {
            variables.Add(name, value);
        }

        private Dictionary<string, double> variables = new Dictionary<string, double>();
    }
}
