using System;
using System.Collections.Generic;

using MathOptimizer.Model.Parser.ExpTree;

namespace MathOptimizer.Model.Entities
{
    /// <summary>
    /// Represents function with scalar or vector argument
    /// </summary>
    /// <remarks>
    /// Container for tree of nodes which convert vector
    /// to set of variables values
    /// </remarks>
    class Function
    {
        /// <summary>
        /// Number of the variables
        /// </summary>
        public int Dimension
        {
            get { return Variables.Count; }
        }
        public List<string> Variables { get; }

        public Function(ExpNode expTree, List<string> variables)
        {
            m_expTree = expTree;
            Variables = variables;
        }
        public virtual double Evaluate(Vector vec)
        {
            if (vec.Size != Variables.Count)
            {
                throw new ArgumentException("Incorrect number of the arguments");
            }

            Values values = new Values();
            for (int i = 0; i < vec.Size; i++)
            {
                values.Assign(Variables[i], vec[i]);
            }

            return m_expTree.Evaluate(values);
        }

        private ExpNode m_expTree;
    }
}
