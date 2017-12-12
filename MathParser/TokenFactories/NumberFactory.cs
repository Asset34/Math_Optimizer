using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a number tokens
    //
    // Formal Grammar:
    //     <Number> ::= <Digit> | <Digit> ',' <Digit>
    //     <Digit>  ::= '0' | ... | '9'
    class NumberFactory
    {
        public bool Check(Position pos)
        {
            return Utills.Check(pos, digitPr);
        }
        public INumberToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                // Main part of the number
                Utills.MoveWhile(pos, digitPr);

                // Fraction part of the number
                Utills.MoveWhile(pos, numSeparatorPr);
                Utills.MoveWhile(pos, digitPr);

                return new NumberToken(Position.MakeString(start, pos));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "NumberFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class NumberToken : Token, INumberToken
        {
            public NumberToken(string strToken)
                : base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        /* Used predicates */
        private readonly Digit digitPr = new Digit();
        private readonly Comma numSeparatorPr = new Comma();
    }
}
