using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Methods.Params
{
    struct Parameters
    {
        public InputParameters inParameters;
        public OutputParameters outParameters;

        public void SwapParameters()
        {
            inParameters.StartInterval = outParameters.ResultInterval;
            inParameters.StartPoint = outParameters.ResultPoint;
        }
    }
}
