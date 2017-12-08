namespace MathOptimizer.Parser.ExpTree
{
    class VariableExp : IExpNode
    {
        public VariableExp(string name)
        {
            this.name = name;
        }
        public double Evaluate(Values values)
        {
            return values.GetValue(name);
        }

        private string name;
    }
    class NumberExp : IExpNode
    {
        public NumberExp(double value)
        {
            this.value = value;
        }
        public double Evaluate(Values values)
        {
            return value;
        }

        private double value;
    }
}
