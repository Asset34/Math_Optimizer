using MathOptimizer;

namespace MathOptimizer.Parser.Func.Tree
{
    abstract class ExpNode : IDeepCloneable<ExpNode>
    {
        public abstract double Evaluate(Values values);
        public abstract ExpNode DeepClone();
    }
}
