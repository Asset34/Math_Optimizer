using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Methods.Params
{
    struct OutputParameters
    {
        public Interval ResultInterval { get; set; }
        public Vector ResultVecPoint   { get; set; }
        public double ResultPoint      { get; set; }
        public int Iterations          { get; set; }
    }
}
