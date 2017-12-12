using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

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
        public bool Check(Position pos)
        {
            return Utills.Check(pos, rbracketPr);
        }
        public IRBracketToken TakeToken(Position pos)
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
        
        /* Used predicates */
        private readonly RBracket rbracketPr = new RBracket();
    }
}
