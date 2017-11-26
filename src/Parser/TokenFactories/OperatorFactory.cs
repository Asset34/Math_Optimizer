using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Tokens;
using MathOptimizer.Parser.Predicates;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a operator tokens
    class OperatorFactory
    {
        static OperatorFactory()
        {
            // Fill operators table
            operatorsTable.Add('+', 1);
            operatorsTable.Add('-', 1);
            operatorsTable.Add('*', 2);
            operatorsTable.Add('/', 2);
            operatorsTable.Add('^', 3);
        }
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, operatorPr);
        }
        public static IOperatorToken TakeToken(Position start)
        {
            if (Check(start))
            {
                Position end = start + 1;

                string strToken = Position.MakeString(start, end);
                int priority = operatorsTable[char.Parse(strToken)];

                return new OperatorToken(strToken, priority);
            }   
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "OperatorFactory";
                ex.Data.Add("Position", start.Number);

                throw ex;
            }    
        }

        /* Produced token */
        private class OperatorToken : IOperatorToken
        {
            public OperatorToken(string str, int priority)
            {
                this.value = str;
                Priority = priority;
            }
            public void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
            public override string ToString()
            {
                return value.ToString();
            }

            public char Operator
            {
                get
                {
                    return char.Parse(value);
                }
            }
            public int Priority { get; }


            private readonly string value;
        }

        /* Local predicate classes */
        public class Operator : ICharCheckPredicate
        {
            public bool Execute(char ch)
            {
                return operatorsTable.ContainsKey(ch);
            }
        }

        /* Used predicates */
        private static readonly Operator operatorPr = new Operator();

        /* Operators table */
        private static Dictionary<char, int> operatorsTable = new Dictionary<char, int>();

        private OperatorFactory() { }
    }
}
