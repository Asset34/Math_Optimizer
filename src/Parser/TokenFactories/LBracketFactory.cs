using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a left bracket tokens
    //
    // Formal Grammar:
    //     <LBracket> ::= '('
    class LBracketFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, lbracketPr);
        }
        public static ILBracketToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                pos++;

                return new LBracketToken(start.Current.ToString(), 0);
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "LBracketFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class LBracketToken : ILBracketToken
        {
            public LBracketToken(string str, int priority)
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

            public int Priority { get; }

            private readonly string value;
        }

        /* Used predicates */
        private static readonly LBracket lbracketPr = new LBracket();

        private LBracketFactory() { }
    }
}
