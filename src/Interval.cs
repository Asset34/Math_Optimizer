using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer
{
    class Interval
    {
        public Interval(double leftBorder, double rightBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;

            checkBorders();
        }
        public Interval()
            : this(0, 0)
        {
        }
        public override string ToString()
        {
            return String.Format("[{0} ; {1}]", LeftBorder, RightBorder);
        }

        public double LeftBorder { get; }
        public double RightBorder { get; }
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
    }
}
