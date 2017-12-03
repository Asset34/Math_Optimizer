using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static int GetFibonacciNumber(int n)
        {
            int FPrev2 = 0;
            int FPrev1 = 1;
            int FCur = 1;

            for (int i = 1; i <= n; i++)
            {
                FCur = FPrev1 + FPrev2;
                FPrev2 = FPrev1;
                FPrev1 = FCur;
            }

            return FCur;
        }
        public static int GetFibonacciIterLimit(double criterion)
        {
            int FPrev2 = 0;
            int FPrev1 = 1;
            int FCur = 1;

            int n = 1;

            while (FCur <= criterion)
            {
                n++;

                FCur = FPrev1 + FPrev2;
                FPrev2 = FPrev1;
                FPrev1 = FCur;
            }

            return n;
        }

        public static double PartialDerivative(Function f, int n, Vector point, double eps)
        {
            Vector point1 = new Vector(point);
            Vector point2 = new Vector(point);

            point1[n] -= eps;
            point2[n] += eps;

            return (f.Evaluate(point1) - 4*f.Evaluate(point) + 3*f.Evaluate(point2)) / (2 * eps);
        }
        public static Vector Gradient(Function f, Vector point, double eps)
        {
            Vector gradient = new Vector(f.Variables.Length);

            for (int i = 0; i < gradient.Size; i++)
            {
                gradient[i] = PartialDerivative(f, i, point, eps);
            }

            return gradient;
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
    }
}
