using MathOptimizer.Model.Entities;
using MathOptimizer.Model.Methods.Params;

namespace MathOptimizer.Model.Methods.MultyDimensional
{
    /// <summary>
    /// Pattern search(Hooke-Jeevec method) - multidimensional 
    /// optimization method
    /// </summary>
    class PatternSearch : OptMethod
    {
        public override void run(Function f, Parameters parameters)
        {
            // Get input parameters
            Vector startPoint = parameters.Input.StartPoint;
            double eps = parameters.Input.Eps;
            double stepValue = parameters.Input.StepValue;
            double stepCoefficient = parameters.Input.StepCoefficient;
            int iterationLimit = parameters.Input.IterationLimit;

            // Set start step
            double startStep = stepValue;
            
            double norm = startPoint.Norm;
            if (norm != 0)
            {
                startStep *= norm;
            }

            // Build the system of coordinate orts
            Vector[] orts = new Vector[f.Dimension];
            Vector nullVector = new Vector(new double[f.Dimension]);

            for (int i = 0; i < f.Dimension; i++)
            {
                Vector ort = new Vector(nullVector);
                ort[i] = 1;

                orts[i] = ort;
            }

            Vector x1 = startPoint, x2, x3, x4;
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

                        minPoint = Utills.MinArg(f, point1, minPoint, point2);
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
                    x3 = 2 * x2 - x1;

                    // Exploratory Search - 2
                    minPoint = x2;
                    Vector basePoint = x3;

                    for (int i = 0; i < orts.Length; i++)
                    {
                        point1 = basePoint - currentStep * orts[i];
                        point2 = basePoint + currentStep * orts[i];

                        minPoint = Utills.MinArg(f, point1, minPoint, point2);

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

            // Set output parameters
            parameters.Output.ResultPoint = x1;
            parameters.Output.Iterations = counter;
        }
    }
}
