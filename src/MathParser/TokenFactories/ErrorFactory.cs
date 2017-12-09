using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser.TokenFactories
{
    class ErrorFactory
    {
        public bool Check(Position pos)
        {
            //return !(NumberFactory.Check(pos)     ||
            //         IdentifierFactory.Check(pos) ||
            //         OperatorFactory.Check(pos)   ||
            //         LBracketFactory.Check(pos)   ||
            //         RBracketFactory.Check(pos));

            /*TEMP*/
            return false;
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
    }
}
