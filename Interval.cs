using System;

namespace MathOptimizer
{
    //
    // Summary:
    //     Represents a math interval:
    //          [ a ; b]  
    class Interval
    {
        public Interval(double leftBorder, double rightBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;

            checkBorders();
        }
        public Interval(Interval interval)
        {
            LeftBorder = interval.LeftBorder;
            RightBorder = interval.RightBorder;
        }
        public override string ToString()
        {
            return String.Format("[{0}; {1}]", LeftBorder, RightBorder);
        }

        public double LeftBorder
        {
            get { return leftBorder; }
            set
            {
                leftBorder = value;
                checkBorders();
            }
        }
        public double RightBorder
        {
            get { return rightBorder; }
            set
            {
                rightBorder = value;
                checkBorders();
            }
        }
        public double Length
        {
            get { return RightBorder - LeftBorder; }
        }
        public double Center
        {
            get { return (LeftBorder + RightBorder) / 2.0; }
        }

        private void checkBorders()
        {
            if (LeftBorder > RightBorder)
            {
                throw new ArgumentException();
            }
        }

        private double leftBorder = Double.MinValue;
        private double rightBorder = Double.MaxValue;
    }
}
