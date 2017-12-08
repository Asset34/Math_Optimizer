using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.MathHandlers;
using MathOptimizer.Func;
using MathOptimizer.Methods;
using MathOptimizer.Methods.OneDimensional;
using MathOptimizer.Methods.Params;
using MathOptimizer.Parser.ExpTree;

namespace MathOptimizer
{
    class Program
    {
        static string[] scalarFunctions = new string[]
        {
            "2*x^2 + 3*exp(-x)"            , // f1
            "-exp(-x)*ln(x)"               , // f2
            "2*x^2 - exp(x)"               , // f3
            "x^4 - 14*x^3 + 60*x^2 - 70*x" , // f4
            "x^2 + 2*x"                    , // f6
            "2*x^2 + 16/x"                 , // f7
            "(10*x^3 + 3*x^2 + x + 5)^2"   , // f8
            "3*x^2 + (12/x^3) - 5"           // f9
        };

        static string[] vectorFunctions1 = new string[]
        {
            "x1^2 + 3*x2^2 + 2*x1*x2"              , // f10
            "100*(x2 - x1^2)^2 + (1 - x1)^2"       , // f11
            "-12*x2 + 4*x1^2 + 4*x2^2 - 4*x1*x2"   , // f12
            "(x1 - 2)^4 + (x1 - 2*x2)^2"           , // f13
            "4*(x1 - 5)^2 + (x2 - 6)^2"            , // f14
            "(x1 - 2)^4 + (x1 - 2*x2)^2"           , // f15
            "2*x1^3 + 4*x1*x2^3 - 10*x1*x2 + x2^2" , // f16
            "8*x1^2 + 4*x1*x2 + 5*x2^2"            , // f17
            "4*(x1 - 5)^2 + (x2 - 6)^2"              // f18
        };

        static string[] vectorFunctions2 = new string[]
        {
            "100*(x2 - x1^2)^2 + (1 - x1)^2"               , // f19
            "(x1 - 1)^2 + (x2 - 3)^2 + 4*(x3 + 5)^2"       , // f20
            "8*x1^2 + 4*x1*x2 + 5*x2^2"                    , // f21
            "4*(x1 - 5)^2 + (x2 - 6)^2"                    , // f22
            "(x2 - x1^2)^2  + (1 - x1)^2"                  , // f23
            "(x2 - x1^2)^2 + 100*(1 - x1)^2"               , // f24
            "3*(x1 - 4)^2 + 5*(x2 + 3)^2 + 7*(2*x3 + 1)^2" , // f25
            "x1^3 + x2^2 - 3*x1 - 2*x2 + 2"                , // f26
        };
    }
}
