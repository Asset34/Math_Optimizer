using System;
using System.Collections.Generic;

using MathOptimizer.Entities;
using MathOptimizer.Parser;
using MathOptimizer.Methods.Params;
using MathOptimizer.Methods.MultyDimensional;

namespace MathOptimizer.WPF.Model
{
    /// <summary>
    /// Model of the application which handle math expression
    /// </summary>
    class ExpHandler
    {
        public List<string> Parse(string exp, string constants)
        {
            // Parse string with constants
            Dictionary<string, double> constDict = m_valParser.Parse(constants);

            // Add dictionary with parsesd constants to the table of constants
            Tables.TempConstantsTable = constDict;

            // Parse string with math expression
            m_function = m_expParser.Parse(exp);

            // Clear table with temprorary constants
            Tables.TempConstantsTable.Clear();

            return m_function.Variables;
        }
        public double Evaluate(string variables)
        {
            Vector vec = CreateVector(variables);

            return m_function.Evaluate(vec);
        }
        public OutputParameters Optimize(string variables)
        {
            Vector vec = CreateVector(variables);

            m_parameters.Input.StartVecPoint = vec;
            m_multyDimMethod.run(m_function, m_parameters);

            return m_parameters.Output;
        }

        private Vector CreateVector(string variables)
        {
            // Parse string with variables
            Dictionary<string, double> vars = m_valParser.Parse(variables);

            // Check for missing variables
            List<string> missingVars = Utills.GetMissing(vars, m_function.Variables);
            if (missingVars.Count > 0)
            {
                ArgumentException ex = new ArgumentException("Non-defined variables");
                ex.Source = "ValuesParser";
                List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
                foreach (string var in missingVars)
                {
                    errors.Add(new KeyValuePair<string, string>(var, "Missing"));
                }
                ex.Data.Add("Errors", errors);

                throw ex;
            }

            // Create vector associated to the list of variables
            Vector vec = Vector.CreateNull(m_function.Dimension);
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i] = vars[m_function.Variables[i]];
            }

            return vec;
        }

        /* Parsed functions */
        private Function m_function;

        /* Optimization methods */
        private MultyDimMethod m_multyDimMethod = new PatternSearch();

        /* Optimization parameters */
        private readonly Parameters m_parameters = new Parameters()
        {
            Input =
            {
                StepValue = 1e-3,
                StepCoefficient = 2,
                Eps = 1e-7,
                IterationLimit = 100
            }
        };

        /* Parsers */
        private readonly ExpParser m_expParser = new ExpParser();
        private readonly ValuesParser m_valParser = new ValuesParser();
    }
}
