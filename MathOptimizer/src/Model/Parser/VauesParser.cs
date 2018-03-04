using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathOptimizer.Model.Parser
{
    /// <summary>
    /// Parser of strings with variables and assigned values
    /// </summary>
    class ValuesParser
    {
        public Dictionary<string, double> Parse(string exp)
        {
            // Preprocessing
            exp = Preprocess(exp);

            // Split
            string[] assignments = SplitToAssignments(exp);

            return CreateTable(assignments);
        }

        private string Preprocess(string exp)
        {
            StringBuilder processedExp = new StringBuilder(exp);

            // Remove all excess elements
            foreach (char element in m_excessElements)
            {
                processedExp.Replace(element.ToString(), string.Empty);
            }

            return processedExp.ToString();
        }
        private string[] SplitToAssignments(string exp)
        {
            // Split expression to assignments
            string[] assignments = exp.Split(m_assignmentSeparators);

            // Remove all empty assignments
            assignments = assignments.Where((str) => (!string.IsNullOrEmpty(str))).ToArray();

            return assignments;
        }
        private Dictionary<string, double> CreateTable(string[] assignments)
        {
            Dictionary<string, double> assignmentsTable = new Dictionary<string, double>();
            List<string> invalidAssignments = new List<string>();
            string[] fields;

            // Add each assignment ot the table
            foreach (string assignment in assignments)
            {
                fields = assignment.Split(m_fieldSeparators);

                if (!CheckAssignment(fields))
                {
                    invalidAssignments.Add(assignment);
                }
                else
                {
                    assignmentsTable.Add(fields[0], double.Parse(fields[1]));
                }
            }

            // Check for invalid assignments        
            if (invalidAssignments.Count > 0)
            {
                ArgumentException ex = new ArgumentException("Invalid assignment");
                ex.Source = "ExpParser";
                List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();

                foreach (string assignment in invalidAssignments)
                {
                    errors.Add(new KeyValuePair<string, string>(assignment, "Invalid assignment"));
                }
                ex.Data.Add("Errors", errors);

                throw ex;
            }

            return assignmentsTable;
        }
        private bool CheckAssignment(string[] assignment)
        {
            // Check length
            if (assignment.Length != 2)
            {
                return false;
            }

            // Check for emptiness
            foreach (string value in assignment)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
            }

            // Check right part of assignment for number
            double res;
            if (!double.TryParse(assignment[1], out res))
            {
                return false;
            }

            return true;
        }

        /* Lists */
        private readonly char[] m_excessElements = new char[]
        {   ' ' ,
            '\n',
            '\t',
            '\r'
        };
        private readonly char[] m_assignmentSeparators = new char[]
        {
            ';',
            ':'
        };
        private readonly char[] m_fieldSeparators = new char[]
        {
            '='
        };
    }
}
