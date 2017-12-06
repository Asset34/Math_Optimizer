using MathOptimizer.Func;

namespace MathOptimizer.Methods
{
    //
    // Summary:
    //     Represents a wrapper class for functions. It is applied for possibility 
    //     to use one-demensional methods for directional optimization
    //     of vector functions
    class ConvertedFunction : Function
    {
        public ConvertedFunction(Function function, Vector startPoint, Vector direction)
            : base(function)
        {
            this.startPoint = startPoint;
            this.direction = direction;
        }
        public override double Evaluate(params double[] values)
        {
            return base.Evaluate(startPoint + values[0] * direction);
        }

        private Vector startPoint;
        private Vector direction;
    }
}
