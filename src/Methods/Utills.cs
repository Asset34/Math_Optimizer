using System;

using MathOptimizer.Parser.Func;

namespace MathOptimizer.Methods
{
    static class Utills
    {
        public static void Normalization(ref double a, ref double b)
        {
            if (a > b)
            {
                double temp = a;

                a = b;
                b = temp;
            }
        }
        public static double Norm(Vector vec)
        {
            double sum = 0;

            for (int i = 0; i < vec.Size; i++)
            {
                sum += vec[i] * vec[i];
            }

            return Math.Sqrt(sum);
        }
        public static Vector minArg(Function f, Vector x1, Vector x2, Vector x3)
        {
            Vector min = x1;

            double f1 = f.Evaluate(x1);
            double f2 = f.Evaluate(x2);
            double f3 = f.Evaluate(x3);

            if (f.Evaluate(x2) < f.Evaluate(min))
            {
                min = x2;
            }

            if (f.Evaluate(x3) < f.Evaluate(min))
            {
                min = x3;
            }

            return min;
        }
    }
}
