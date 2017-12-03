using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Func;

namespace MathOptimizer.Methods
{
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
