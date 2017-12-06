namespace MathOptimizer.Parser.Func.Tree
{
    class VariableExp : IExpNode
    {
        public VariableExp(string name)
        {
            Name = name;
        }
        public double Evaluate(Values values)
        {
            return values.GetValue(Name);
        }

        public string Name { get; }
    }
    class NumberExp : IExpNode
    {
        public NumberExp(double value)
        {
            Value = value;
        }
        public double Evaluate(Values values)
        {
            return Value;
        }

        public double Value { get; }
    }
}
