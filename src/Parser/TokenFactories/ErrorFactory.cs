using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    class ErrorFactory
    {
        public static bool Check(Position pos)
        {
            return !(NumberFactory.Check(pos)     ||
                     IdentifierFactory.Check(pos) ||
                     OperatorFactory.Check(pos)   ||
                     LBracketFactory.Check(pos)   ||
                     RBracketFactory.Check(pos));
        }
        public static IErrorToken TakeToken(Position pos)
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
        private class ErrorToken : IErrorToken
        {
            public ErrorToken(string str)
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

        private ErrorFactory() { }
    }
}
