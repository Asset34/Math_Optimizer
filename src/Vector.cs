using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer
{
    class Vector
    {
        public Vector(params double[] coords)
        {
            this.coords = new double[coords.Length];

            Array.Copy(coords, this.coords, coords.Length);
        }
        public Vector(Vector vec)
            : this(vec.coords)
        {
        }
        public static Vector operator+(Vector vec1, Vector vec2)
        {
            if (vec1.Size != vec2.Size)
            {
                throw new ArgumentException("Sum of unequal vectors");
            }

            Vector result = new Vector(vec1);

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

            Vector result = new Vector(vec1);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vec1[i] - vec2[i];
            }

            return result;
        }
        public static Vector operator*(double scalar, Vector vec)
        {
            Vector result = new Vector(vec);

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
            Vector result = new Vector(vec);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vec[i] / scalar;
            }

            return result;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append('(');
            foreach (double val in coords)
            {
                str.Append(val + "; ");
            }
            str.Remove(str.Length - 2, 2);
            str.Append(')');

            return str.ToString();
        }

        public int Size
        {
            get
            {
                return coords.Length;
            }
        }
        public double this[int key]
        {
            get
            {
                return coords[key];
            }
            set
            {
                coords[key] = value;
            }
        }

        private double[] coords;
    }
}
