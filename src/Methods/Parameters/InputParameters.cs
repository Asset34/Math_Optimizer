using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Methods.Params
{
    struct InputParameters
    {
        public Interval StartInterval { get; set; }
        public double StartPoint      { get; set; }
        public double StepValue       { get; set; }
        public double Eps             { get; set; }
        public int IterationLimit     { get; set; } 
    }
}
