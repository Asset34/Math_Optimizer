using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a right bracket tokens
    //
    // Formal Grammar:
    //     <RBracket> ::= ')'
    class RBracketFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, rbracketPr);
        }
        public static IRBracketToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                pos++;

                return new RBracketToken(start.Current.ToString());
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
        private class RBracketToken : Token, IRBracketToken
        {
            public RBracketToken(string strToken)
                :base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        /* Local predicates */
        private class RBracket : ICharPredicate
        {
            public bool Execute(char ch)
            {
                return ch == ')';
            }
        }

        /* Used predicates */
        private static readonly RBracket rbracketPr = new RBracket();

        private RBracketFactory() { }
    }
}
