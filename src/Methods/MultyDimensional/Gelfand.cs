using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Func;
using MathOptimizer.Methods.Params;
using MathOptimizer.Methods.OneDimensional;

namespace MathOptimizer.Methods.MultyDimensional
{
    class Gelfand : MultyDimensionalMethod
    {
        public override void run(Function f, OneDimensionalMethod method, ref Parameters parameters)
        {
            /* Get input parameters */
            double eps = parameters.inParameters.Eps;
            Vector startPoint = parameters.inParameters.StartVecPoint;
            int iterationLimit = parameters.inParameters.IterationLimit;

            /* Optimization */

            Vector point1;
            Vector point2;
            Vector point3 = new Vector(startPoint);
            Vector direction;

            int counter = 0;

            do
            {
                // Set 1st start point
                point1 = new Vector(point3);

                // Set 2nd start point
                point2 = new Vector(point1);
                point2[0] += eps;

                // Get 1st result point
                direction = -1 * Utills.Gradient(f, point1, eps);
                point1 = DirectionDescent(f, point1, direction, method, ref parameters);

                // Get 2nd result point
                direction = -1 * Utills.Gradient(f, point2, eps);
                point2 = DirectionDescent(f, point2, direction, method, ref parameters);

                // Set new search direction
                direction = point1 - point2;

                // Get 3rd result point
                point3 = DirectionDescent(f, point1, direction, method, ref parameters);

                counter++;
            }
            while (Utills.Norm(point1 - point3) > eps && counter < iterationLimit);

            /* Set output parameters */

        }

        private Vector DirectionDescent(Function f, Vector startPoint, Vector direction, 
                                        OneDimensionalMethod method, ref Parameters parameters)
        {
            double eps = parameters.inParameters.Eps;
            ConvertedFunction cf = new ConvertedFunction(f, startPoint, direction);

            // Set start direction step
            parameters.inParameters.StartPoint = 0;

            method.run(cf, ref parameters);

            // Get result direction step
            double resultStep = parameters.outParameters.ResultPoint;

            return startPoint + resultStep * direction;
        }

    }
}
