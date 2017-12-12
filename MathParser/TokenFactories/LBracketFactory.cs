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
        public bool Check(Position pos)
        {
            return Utills.Check(pos, lbracketPr);
        }
        public ILBracketToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                pos++;

                return new LBracketToken(start.Current.ToString());
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
        private class LBracketToken : Token, ILBracketToken
        {
            public LBracketToken(string strToken)
                :base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        /* Used predicates */
        private readonly LBracket lbracketPr = new LBracket();
    }
}
