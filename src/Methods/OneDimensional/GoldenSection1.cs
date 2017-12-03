using System;

using MathOptimizer.Parser.Func;
using MathOptimizer.Methods.Params;

namespace MathOptimizer.Methods.OneDimensional
{
    class GoldenSection1 : OneDimensionalMethod
    {
        public override void run(Function f, ref Parameters parameters)
        {
            /* Get input parameters */
            Interval inputInterval = parameters.inParameters.StartInterval;
            double eps = parameters.inParameters.Eps;
            double iterationLimit = parameters.inParameters.IterationLimit;

            /* Optimization */
            Interval outputInterval = new Interval(inputInterval);

            // Gold numbers
            double T1 = (Math.Sqrt(5.0) - 1.0)/2.0;
            double T2 = (3 - Math.Sqrt(5.0))/2.0;

            double x1 = outputInterval.LeftBorder + T2 * outputInterval.Length;
            double x2 = outputInterval.LeftBorder + T1 * outputInterval.Length;
            int counter = 0;

            while (outputInterval.Length > eps && counter < iterationLimit)
            {
                if (f.Evaluate(x1) >= f.Evaluate(x2))
                {
                    outputInterval.LeftBorder = x1;
                    x1 = x2;
                    x2 = outputInterval.LeftBorder + T1 * outputInterval.Length;
                }
                else
                {
                    outputInterval.RightBorder = x2;
                    x2 = x1;
                    x1 = outputInterval.LeftBorder + T2 * outputInterval.Length;
                }

                counter++;
            }

            /* Set output parameters */
            parameters.outParameters.ResultInterval = outputInterval;
            parameters.outParameters.ResultPoint = outputInterval.Center;
            parameters.outParameters.Iterations = counter;
        }
    }
}
