namespace MathOptimizer.Parser.Func.Tree
{
    class VariableExp : ExpNode
    {
        public VariableExp(string name)
        {
            Name = name;
        }
        public override double Evaluate(Values values)
        {
            return values.GetValue(Name);
        }
        public override ExpNode DeepClone()
        {
            return new VariableExp(Name);
        }

        public string Name { get; }
    }
    class NumberExp : ExpNode
    {
        public NumberExp(double value)
        {
            Value = value;
        }
        public override double Evaluate(Values values)
        {
            return Value;
        }
        public override ExpNode DeepClone()
        {
            return new NumberExp(Value);
        }

        public double Value { get; }
    }
}
