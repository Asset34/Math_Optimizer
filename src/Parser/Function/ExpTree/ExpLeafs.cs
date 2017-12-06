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

    class IndexedVariableExp : ExpNode
    {
        public IndexedVariableExp(string name, int index)
        {
            Name = name;
            Index = index;
        }
        public IndexedVariableExp(string name)
            :this(name, 0)
        {
        }
        public override double Evaluate(Values values)
        {
            return values.GetValue(FullName);
        }
        public override ExpNode DeepClone()
        {
            return new IndexedVariableExp(Name, Index);
        }

        public string Name { get; }
        public int Index { get; set; }
        public string FullName
        {
            get { return Name + Index.ToString(); }
        }
    }
    class IndexExp : ExpNode
    {
        public IndexExp(double value)
        {
            Value = value;
        }
        public override double Evaluate(Values values)
        {
            return Value;
        }
        public override ExpNode DeepClone()
        {
            return new IndexExp(Value);
        }

        public double Value { get; }
    }
}
