namespace MathOptimizer.Model.  Parser.ExpTree
{
    class VariableLeaf : ExpNode
    {
        public string Name { get; }

        public VariableLeaf(string name)
        {
            Name = name;
        }
        public override double Evaluate(Values values)
        {
            return values.GetValue(Name);
        }
    }

    class NumberLeaf : ExpNode
    {
        public double Value { get; }

        public NumberLeaf(double value)
        {
            Value = value;
        }
        public override double Evaluate(Values values)
        {
            return Value;
        }
    }
}
