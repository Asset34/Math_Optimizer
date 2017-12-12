using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    class ErrorFactory
    {
        public bool Check(Position pos)
        {
            return !(Utills.Check(pos, notErrorPr));
        }
        public IErrorToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                while (!pos.IsEnd && Check(pos))
                {
                    pos++;
                }

                return new ErrorToken(Position.MakeString(start, pos));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "ErrorFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class ErrorToken : Token, IErrorToken
        {
            public ErrorToken(string strToken)
                :base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        /* Used predicates */
        private readonly DisjunctionCharPredicate notErrorPr = new DisjunctionCharPredicate()
        {
            Predicates =
            {
                new Letter(),
                new Digit(),
                new Operator(),
                new LBracket(),
                new RBracket(),
                new Comma(),
                new Semicolon(),
                new Underscore()
            }
        };
    }
}
