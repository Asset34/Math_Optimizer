namespace MathOptimizer.Parser.ExpTree
{
    /// <summary>
    /// Base class for math expression nodes
    /// </summary>
    abstract class ExpNode
    {
        public abstract double Evaluate(Values values);
    }
}
