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
    //class Cauchy : MultyDemensionalMethod
    //{
    //    public override void run(Function f, OneDimensionalMethod method, Parameters parameters)
    //    {
    //        /* Get input values */
    //        double eps = parameters.inParameters.Eps;
    //        Vector startPoint = parameters.inParameters.StartVector;
    //        int iterLimit = parameters.inParameters.IterationLimit;

    //        /* Optimization */

    //        Vector point = startPoint;
    //        Vector prevPoint;
    //        int counter = 0;

    //        do
    //        {
    //            parameters.inParameters.Direction = -1 * Utills.Gradient(f, point, eps);

    //            Console.WriteLine("Direction: {0}", parameters.inParameters.Direction);

    //            method.run(f, parameters);

    //            prevPoint = point;
    //            //point = point + parameters.outParameters.ResultPoint * parameters.inParameters.Direction;

    //            point = parameters.outParameters.ResultVector;

    //            counter++;
    //        }
    //        while ((Utills.Norm(point - prevPoint) > eps || Math.Abs(f.Evaluate(point) - f.Evaluate(prevPoint)) > eps) &&
    //               counter <= iterLimit);

    //        /* Set output values */
    //        parameters.outParameters.ResultVector = point;
    //        parameters.outParameters.Iterations = counter;
    //    }
    //}
}
