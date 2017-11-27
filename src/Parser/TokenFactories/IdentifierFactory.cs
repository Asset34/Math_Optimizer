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
    //     Represents a factory of a identifier tokens
    //     (Variables and Function Names)
    class IdentifierFactory
    {
        static IdentifierFactory()
        {
            // Build a predicate for start of the identifier
            beginVariablePr.Predicates.Add(new Underscore());
            beginVariablePr.Predicates.Add(new Letter());

            // Build a predicate for other part of the identifier
            variablePr.Predicates.Add(beginVariablePr);
            variablePr.Predicates.Add(new Digit());
        }
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, beginVariablePr);
        }
        public static IToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                Utills.MoveWhile(pos, variablePr);

                string strToken = Position.MakeString(start, pos);

                /* Specificate indentificator */
                if (functionNamesTable.Contains(strToken))
                {
                    return new FunctionNameToken(strToken);
                }
                else
                {
                    return new VariableToken(strToken);
                }
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "IdentifierFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced tokens */
        private class VariableToken : IVariableToken
        {
            public VariableToken(string str)
            {
                this.value = str;
            }
            public void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
            public override string ToString()
            {
                return value;
            }

            private readonly string value;
        }
        private class FunctionNameToken : IFunctionNameToken
        {
            public FunctionNameToken(string str)
            {
                this.value = str;
            }
            public void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
            public override string ToString()
            {
                return value;
            }

            private readonly string value;
        }

        /* Used predicates */
        private static DisjunctionPredicate beginVariablePr = new DisjunctionPredicate();
        private static DisjunctionPredicate variablePr = new DisjunctionPredicate();

        private IdentifierFactory() { }

        /* Function names table */
        private static string[] functionNamesTable = new string[]
        {
            "sin" , "cos", "tg",
            "ctg" , "exp", "ln",
            "sqrt"
        };
    }
}
