using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser
{
    class MathAssignmentParser
    {
        public static Dictionary<string, double> Parser(string exp)
        {
            // Preprocessing
            exp = parser.Preprocess(exp);

            // Split
            string[] assignments = parser.SplitToAssignments(exp);

            // Create table
            return parser.createTable(assignments);
        }

        private MathAssignmentParser()
        {
        }
        private string Preprocess(string exp)
        {
            StringBuilder processedExp = new StringBuilder(exp);

            // Remove all excess elements
            foreach (char element in excessElements)
            {
                processedExp.Replace(element.ToString(), String.Empty);
            }

            return processedExp.ToString();
        }
        private string[] SplitToAssignments(string exp)
        {
            // Split expression to assignments
            string[] assignments = exp.Split(assignmentSeparators);

            // Remove all empty assignments
            assignments = assignments.Where((str) => (!String.IsNullOrEmpty(str))).ToArray();

            return assignments;
        }
        private Dictionary<string, double> createTable(string[] assignments)
        {
            Dictionary<string, double> assignmentsTable = new Dictionary<string, double>();
            List<string> invalidAssignments = new List<string>();
            string[] fields;

            // Add each assignment ot the table
            foreach (string assignment in assignments)
            {
                fields = assignment.Split(fieldSeparators);

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
                ArgumentException exc = new ArgumentException("Invalid string with assignments");

                exc.Source = "MathAssignmentParser";

                foreach (string assignment in invalidAssignments)
                {
                    exc.Data.Add(assignment, "Invalid assignment");
                }

                throw exc;
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
                if (String.IsNullOrEmpty(value))
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

        static private readonly MathAssignmentParser parser = new MathAssignmentParser();

        /* Lists */
        private readonly char[] excessElements = new char[]
        {   ' ' ,
            '\n',
            '\t',
            '\r'
        };
        private readonly char[] assignmentSeparators = new char[]
        {
            ';',
            ':'
        };
        private readonly char[] fieldSeparators = new char[]
        {
            '='
        };
    }
}
