using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer;
using MathOptimizer.Parser;
using MathOptimizer.Methods.Params;
using MathOptimizer.Methods.OneDimensional;
using MathOptimizer.Methods.MultyDimensional;

namespace MathOptimizer.MVVM
{
    class MathOptimizerModel
    {
        public MathOptimizerModel()
        {
            SetDefaultParameters();
        }
        public void ParseExp(string expString, string constString)
        {
            AddTemproraryConstants(constString);
            function = MathExpressionParser.Parse(expString);
            RemoveTemproraryConstants();
        }
        public void Evaluate(string variablesString)
        {
            Vector point = CreateVector(variablesString);

            EvaluateResult = function.Evaluate(point);
        }
        public void Optimize(string variablesString)
        {
            Vector startPoint = CreateVector(variablesString);

            SetStartPoint(startPoint);
            method.run(function, internalMethod, ref parameters);

            OptimizeResult_point = parameters.OutParameters.ResultVecPoint;
            OptimizeResult_iterations = parameters.OutParameters.Iterations;
        }

        public string[] Variables
        {
            get { return function.Variables; }
        }
        public double EvaluateResult { get; set; }
        public Vector OptimizeResult_point { get; set; }
        public int OptimizeResult_iterations { get; set; }

        private Dictionary<string, double> ParseVariables(string variablesString)
        {
            Dictionary<string, double> variables = MathAssignmentParser.Parser(variablesString);
            List<string> missingVariables = Utills.CheckContent(variables, function.Variables);

            if (missingVariables.Count > 0)
            {
                ArgumentException exc = new ArgumentException("Non-defined variables");

                exc.Source = "MathAssignmentParser";

                foreach (string var in missingVariables)
                {
                    exc.Data.Add(var, "Missing");
                }

                throw exc;
            }

            return variables;
        }
        private void AddTemproraryConstants(string constString)
        {
            Tables.TempConstantsTable = MathAssignmentParser.Parser(constString);
        }
        private void RemoveTemproraryConstants()
        {
            Tables.TempConstantsTable.Clear();
        }
        private Vector CreateVector(string variablesString)
        {
            Vector vec = Vector.CreateNullVector(function.Variables.Length);
            Dictionary<string, double> variables = ParseVariables(variablesString);
           
            for (int i = 0; i < function.Variables.Length; i++)
            {
                vec[i] = variables[function.Variables[i]];
            }

            return vec;
        }
        private void SetDefaultParameters()
        {
            parameters.InParameters.StepValue = 1e-3;
            parameters.InParameters.StepCoefficient = 2;
            parameters.InParameters.Eps = 1e-7;
            parameters.InParameters.IterationLimit = 100;
        }
        private void SetStartPoint(Vector startPoint)
        {
            parameters.InParameters.StartVecPoint = startPoint;
        }

        private Function function;
        private Parameters parameters;
        private MultyDimensionalMethod method = new PatternSearch();
        private OneDimensionalMethod internalMethod = new CompositeOneDimensionalMethod();
    }
}
