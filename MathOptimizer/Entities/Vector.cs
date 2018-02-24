using System;
using System.Text;

namespace MathOptimizer.Entities
{
    /// <summary>
    /// Performs math vector with any dimension
    /// </summary>
    class Vector
    {
        public int Size
        {
            get{ return m_coords.Length; }
        }
        public double this[int key]
        {
            get{ return m_coords[key]; }
            set{ m_coords[key] = value; }
        }

        public Vector(params double[] coords)
        {
            m_coords = coords;
        }
        public Vector(Vector vec)
        {
            m_coords = (double[])vec.m_coords.Clone();
        }

        public static Vector operator+(Vector vec1, Vector vec2)
        {
            if (vec1.Size != vec2.Size)
            {
                throw new ArgumentException("Sum of unequal vectors");
            }

            Vector result = CreateNull(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vec1[i] + vec2[i];
            }

            return result;
        }
        public static Vector operator-(Vector vec1, Vector vec2)
        {
            if (vec1.Size != vec2.Size)
            {
                throw new ArgumentException("Substraction of unequal vectors");
            }

            Vector result = CreateNull(vec1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vec1[i] - vec2[i];
            }

            return result;
        }
        public static Vector operator*(double scalar, Vector vec)
        {
            Vector result = CreateNull(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vec[i] * scalar;
            }

            return result;
        }
        public static Vector operator*(Vector vec, double scalar)
        {
            return scalar * vec;
        }
        public static Vector operator/(Vector vec, double scalar)
        {
            Vector result = CreateNull(vec.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vec[i] / scalar;
            }

            return result;
        }

        /// <summary>
        /// Compute norm of the vector
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static double Norm(Vector vec)
        {
            double sum = 0;

            for (int i = 0; i < vec.Size; i++)
            {
                sum += vec[i] * vec[i];
            }

            return Math.Sqrt(sum);
        }
        /// <summary>
        /// Create vector of the following form: (0,0, ... ,0)
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Vector CreateNull(int size)
        {
            return new Vector(new double[size]);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append('(');
            foreach (double coord in m_coords)
            {
                str.Append(string.Format("{0}; ", coord));
            }
            str.Remove(str.Length - 2, 2);
            str.Append(')');

            return str.ToString();
        }

        private double[] m_coords;
    }
}
