using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Func;
using MathOptimizer.Methods.Params;

namespace MathOptimizer.Methods.OneDimensional
{
    class Fibonacci1 : OneDimensionalMethod
    {
        public override void run(Function f, ref Parameters parameters)
        {
            /* Get input parameters */
            Interval inputInterval = parameters.inParameters.StartInterval;
            double eps = parameters.inParameters.Eps;

            /* Optimization */

            Interval outputInterval = new Interval(inputInterval);
            int n = Utills.GetFibonacciIterLimit(outputInterval.Length / eps);

            // Fibonacci numbers
            double FCur   = Utills.GetFibonacciNumber(n);
            double FPrev1 = Utills.GetFibonacciNumber(n - 1);
            double FPrev2 = Utills.GetFibonacciNumber(n - 2);

            double x1 = outputInterval.LeftBorder + FPrev2 / FCur * outputInterval.Length;
            double x2 = outputInterval.LeftBorder + FPrev1 / FCur * outputInterval.Length;

            for (int i = 0; i < n - 1; i++)
            {
                FCur   = FPrev1;
                FPrev1 = FPrev2;
                FPrev2 = FCur - FPrev1;

                if (f.Evaluate(x1) >= f.Evaluate(x2))
                {
                    outputInterval.LeftBorder = x1;

                    x1 = x2;
                    x2 = outputInterval.LeftBorder + FPrev1 / FCur * outputInterval.Length;
                }
                else
                {
                    outputInterval.RightBorder = x2;

                    x2 = x1;
                    x1 = outputInterval.LeftBorder + FPrev2 / FCur * outputInterval.Length;
                }
            }

            // Special final step (F0 = F1)
            double DELTA = inputInterval.Length / Utills.GetFibonacciNumber(n + 1);

            x2 = x1 + DELTA;

            if (f.Evaluate(x1) >= f.Evaluate(x2))
            {
                outputInterval.LeftBorder = x1;
            }
            else
            {
                outputInterval.RightBorder = x2;
            }

            /* Set output parameters */
            parameters.outParameters.ResultInterval = outputInterval;
            parameters.outParameters.ResultPoint = outputInterval.Center;
            parameters.outParameters.Iterations = n;
        }
    }
}
