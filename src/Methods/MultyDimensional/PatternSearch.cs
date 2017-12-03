using MathOptimizer.Parser.Func;
using MathOptimizer.Methods.OneDimensional;
using MathOptimizer.Methods.Params;

namespace MathOptimizer.Methods
{
    class PatternSearch
    {
        public void run(Function f, OneDimensionalMethod method, ref Parameters parameters)
        {
            /* Get input parameters */
            Vector startPoint = parameters.inParameters.StartVecPoint;
            double eps = parameters.inParameters.Eps;
            double stepValue = parameters.inParameters.StepValue;
            double stepCoefficient = parameters.inParameters.StepCoefficient;
            int iterationLimit = parameters.inParameters.IterationLimit;

            // Set start step
            double startStep = stepValue;

            double norm = Utills.Norm(startPoint);
            if (norm != 0)
            {
                startStep *= norm;
            }

            // Build the system of coordinate orts
            Vector[] orts = new Vector[f.Variables.Length];
            Vector nullVector = new Vector(new double[f.Variables.Length]);

            for (int i = 0; i < f.Variables.Length; i++)
            {
                Vector ort = new Vector(nullVector);
                ort[i] = 1;

                orts[i] = ort;
            }

            Vector x1 = startPoint;
            Vector x2;
            Vector x3;
            Vector x4;
            Vector direction;
            double currentStep = startStep;
            int counter = 0;
            do
            {
                // Exploratory Search - 1
                Vector point1;
                Vector point2;
                Vector minPoint;              
                do
                {
                    minPoint = x1;

                    for (int i = 0; i < orts.Length; i++)
                    {
                        point1 = minPoint - currentStep * orts[i];
                        point2 = minPoint + currentStep * orts[i];

                        minPoint = Utills.minArg(f, point1, minPoint, point2);
                    }

                    // Step division
                    if (x1 == minPoint)
                    {
                        currentStep /= stepCoefficient;
                    }
                }
                while (currentStep > eps && x1 == minPoint);

                x2 = minPoint;

                // Success
                if (currentStep <= eps)
                {
                    break;
                }

                do
                {
                    // Accelerated Search
                    direction = x2 - x1;
                    ConvertedFunction cf = new ConvertedFunction(f, x2, direction);
                    parameters.inParameters.StartPoint = 0;

                    method.run(cf, ref parameters);

                    x3 = x2 + parameters.outParameters.ResultPoint * direction;

                    // Exploratory Search - 2
                    minPoint = x2;
                    Vector basePoint = x3;

                    for (int i = 0; i < orts.Length; i++)
                    {
                        point1 = basePoint - currentStep * orts[i];
                        point2 = basePoint + currentStep * orts[i];

                        minPoint = Utills.minArg(f, point1, minPoint, point2);
                        
                        if (minPoint != x2)
                        {
                            basePoint = minPoint;
                        }
                    }

                    x4 = minPoint;

                    // Failure
                    if (minPoint == x2)
                    {
                        x1 = x2;
                        break;
                    }
                    // Success
                    else
                    {
                        x1 = x2;
                        x2 = x4;
                    }
                }
                while (true);

                counter++;
            }
            while (counter < iterationLimit);

            /* Set output parameters */
            parameters.outParameters.ResultVecPoint = x1;
            parameters.outParameters.Iterations = counter;
        }
    }
}
