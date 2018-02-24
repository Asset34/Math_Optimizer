using System;

namespace MathOptimizer.Entities
{
    /// <summary>
    /// Represents the math interval
    /// </summary>
    class Interval
    {
        /// <summary>
        /// Left border of the interval
        /// </summary>
        public double Left
        {
            get { return m_left; }
            set { m_left = value; checkBorders(); }
        }
        /// <summary>
        /// Right border of the interval
        /// </summary>
        public double Right
        {
            get { return m_right; }
            set { m_right = value; checkBorders(); }
        }

        public double Center
        {
            get { return (Left + Right)/2.0; }
        }
        public double Length
        {
            get { return Right - Left; }
        }
        
        public Interval(double left, double right)
        {
            m_left = left;
            m_right = right;

            checkBorders();
        }
        public Interval(Interval interval)
        {
            Left = interval.Left;
            Right = interval.Right;
        }

        public override string ToString()
        {
            return string.Format("[{0}; {1}]", Left, Right);
        }

        private void checkBorders()
        {
            if (Left > Right)
            {
                throw new ArgumentException();
            }
        }

        private double m_left;
        private double m_right;
    }
}
