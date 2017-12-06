using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.MathHandlers;
using MathOptimizer.Parser.Func;
using MathOptimizer.Methods;
using MathOptimizer.Methods.OneDimensional;
using MathOptimizer.Methods.Params;
using MathOptimizer.Parser.Func.Tree;

namespace MathOptimizer
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str;

            try
            {
                Function func = CreateFunction("2 + sin(x1 + x2^(4 - 4,54)) * sqrt(8)");

                Console.WriteLine("{0}", func.Evaluate(3, 54.542));
            }
            catch (Exception e)
            {
                Console.WriteLine("%Error%: {0} - {1}", e.Source, e.Message);
                
                foreach (object obj in e.Data.Keys)
                {
                    Console.WriteLine("---> {0}: {1}", obj, e.Data[obj]);
                }

                //Console.WriteLine("{0}", e.StackTrace);
            }
        }

        static void TestNewMethod()
        {
            Function function = CreateFunction(vectorFunctions2[5]);
            OneDimensionalMethod m1 = new Swan1();
            OneDimensionalMethod m2 = new GoldenSection1();
            CompositeOneDimensionalMethod mm = new CompositeOneDimensionalMethod();
            PatternSearch method = new PatternSearch();

            mm.Methods.Add(m1);
            mm.Methods.Add(m2);

            Parameters parameters = new Parameters();

            parameters.inParameters.StepValue = 0.001;
            parameters.inParameters.StepCoefficient = 2;
            parameters.inParameters.Eps = 1e-5;
            parameters.inParameters.StartVecPoint = new Vector(200, -1954.544);
            parameters.inParameters.IterationLimit = 200;

            method.run(function, mm, ref parameters);

            Console.WriteLine("Result: {0}", parameters.outParameters.ResultVecPoint);
        }

        static Function CreateFunction(string exp)
        {
            List<IToken> tokens = new List<IToken>();
            Function function;

            tokens = MathTokenizer.Tokenize(exp);
            MathGrammarScanner.Scann(tokens);
            tokens = MathRPNConverter.Convert(tokens);
            function = MathFunctionCreator.Create(tokens);

            return function;
        }

















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
