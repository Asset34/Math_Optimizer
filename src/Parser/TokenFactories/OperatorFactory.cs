using System;
using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a operator tokens
    class OperatorFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, operatorPr);
        }
        public static IOperatorToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                pos++;

                string strToken = start.Current.ToString();
                
                if (CheckUnaryOp(start))
                {
                    int priority = unaryOperatorsTable[start.Current];

                    return new UnaryOpToken(strToken, priority);
                }
                else
                {
                    int priority = binaryOperatorsTable[start.Current];

                    return new BinaryOpToken(strToken, priority);
                }
            }   
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "OperatorFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }    
        }

        private static bool CheckUnaryOp(Position pos)
        {
            Position prevPos = pos - 1;

            // If <UnaryOp> is a first character
            if (prevPos.IsBegin)
            {
                return true;
            }

            // If <UnaryOp> located after the left bracket ')'
            if (Utills.Check(pos - 1, lbracketPr) &&
                unaryOperatorsTable.ContainsKey(pos.Current))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Produced token */
        private class BinaryOpToken : IBinaryOpToken
        {
            public BinaryOpToken(string str, int priority)
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
        private class UnaryOpToken : IUnaryOpToken
        {
            public UnaryOpToken(string str, int priority)
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
        private class Operator : ICharPredicate
        {
            public bool Execute(char ch)
            {
                return binaryOperatorsTable.ContainsKey(ch);
            }
        }

        /* Used predicates */
        private static readonly Operator operatorPr = new Operator();
        private static readonly LBracket lbracketPr = new LBracket();

        /* Binary Operators table */
        private static Dictionary<char, int> binaryOperatorsTable = new Dictionary<char, int>()
        {
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2},
            {'^', 3}
        };

        /* Unary Operators table */
        private static Dictionary<char, int> unaryOperatorsTable = new Dictionary<char, int>()
        {
            {'+', 4},
            {'-', 4}
        };

        private OperatorFactory() { }
    }
}
