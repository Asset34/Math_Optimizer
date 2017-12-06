using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Func;
using MathOptimizer.Methods.OneDimensional;
using MathOptimizer.Methods.MultyDimensional;
using MathOptimizer.Methods.Params;

using MathOptimizer.Parser;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.MathHandlers;
using MathOptimizer.Methods;
using MathOptimizer.Func.Tree;

namespace MathOptimizer
{
    static class FunctionContainer
    {
        static FunctionContainer()
        {
            SetDefaultParameters();
            SetMethods();
        }
        public static string[] Parser(string expression)
        {
            List<IToken> tokens = MathTokenizer.Tokenize(expression);
            MathGrammarScanner.Scann(tokens);
            tokens = MathRPNConverter.Convert(tokens);
            function = MathFunctionCreator.Create(tokens);

            // Remove all constants
            foreach (string constant in tempConstants)
            {
                Tables.ConstantsTable.Remove(constant);
            }

            return function.Variables;
        }
        public static double Evaluate(Vector point)
        {
            return function.Evaluate(point);
        }
        public static Vector Optimize(Vector startPoint)
        {
            parameters.InParameters.StartVecPoint = startPoint;
            method.run(function, internalMethod, ref parameters);

            return parameters.OutParameters.ResultVecPoint;
        }
        public static void AddConstant(string str, double value)
        {
            Tables.ConstantsTable.Add(str, value);
            tempConstants.Add(str);
        }

        private static void SetDefaultParameters()
        {
            parameters.InParameters.Eps = 1e-7;
            parameters.InParameters.StepValue = 1e-3;
            parameters.InParameters.StepCoefficient = 2;
            parameters.InParameters.IterationLimit = 100;
        }
        private static void SetMethods()
        {
            CompositeOneDimensionalMethod compositeMethod = new CompositeOneDimensionalMethod();
            compositeMethod.Methods.Add(new Swan1());
            compositeMethod.Methods.Add(new GoldenSection1());
            internalMethod = compositeMethod;

            method = new PatternSearch();
        }

        private static Function function;
        private static Parameters parameters;
        private static OneDimensionalMethod internalMethod;
        private static MultyDimensionalMethod method;

        private static List<string> tempConstants = new List<string>();
    }
}
