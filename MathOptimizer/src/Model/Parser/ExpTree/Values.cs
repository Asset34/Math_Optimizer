using System.Collections.Generic;

namespace MathOptimizer.Model.Parser.ExpTree
{
    /// <summary>
    /// Class which links values to variables
    /// </summary>
    class Values
    {
        public double GetValue(string name)
        {
            return m_variables[name];
        }
        /// <summary>
        /// Assign specific value to the variable
        /// </summary>
        /// <param name="name"> name of the variable </param>
        /// <param name="value"> specific value </param>
        public void Assign(string name, double value)
        {
            m_variables.Add(name, value);
        }

        private Dictionary<string, double> m_variables = new Dictionary<string, double>();
    }
}
