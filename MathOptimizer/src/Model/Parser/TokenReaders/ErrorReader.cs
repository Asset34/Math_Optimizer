using System;

using MathOptimizer.Model.Entities;
using MathOptimizer.Model.Parser.Predicates;

namespace MathOptimizer.Model.Parser.TokenReaders
{
    /// <summary>
    /// Class which try to read 'ErroToken' from
    /// the spicific position
    /// </summary>
    partial class ErrorReader : TokenReader
    {
        public override bool Check(Position pos)
        {
            return !(Utills.Check(pos, notErrorPr));
        }
        public override IToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);
                while (!pos.IsEnd && Check(pos))
                {
                    pos++;
                }

                return new ErrorToken(Position.CreateString(start, pos));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");
                ex.Source = "ErrorReader";

                throw ex;
            }
        }

        /* Used predicates */
        private readonly DisjunctionPrOf1<char> notErrorPr = new DisjunctionPrOf1<char>()
        {
            Predicates =
            {
                new LetterPr(),
                new DigitPr(),
                new OperatorPr(),
                new LBracketPr(),
                new RBracketPr(),
                new SemicolonPr(),
                new UnderscorePr()
            }
        };
    }
}
