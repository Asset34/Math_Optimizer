using System;

using MathOptimizer.Parser.ExpTree;

namespace MathOptimizer
{
    class Function
    {
        public Function(IExpNode expTree, string[] variables)
        {
            this.expTree = expTree;
            Variables = variables;
        }
        public Function(Function f)
            : this(f.expTree, f.Variables)
        {
        }
        public double Evaluate(Vector vec)
        {
            if (vec.Size != Variables.Length)
            {
                throw new ArgumentException("Incorrect number of the arguments");
            }

            Values values = new Values();

            for (int i = 0; i < vec.Size; i++)
            {
                values.Assign(Variables[i], vec[i]);
            }

            return expTree.Evaluate(values);
        }
        public virtual double Evaluate(params double[] values)  
        {
            return Evaluate(new Vector(values));
        }

        public string[] Variables { get; }

        private IExpNode expTree;
    }
}
