using System;

using MathOptimizer.Entities;
using MathOptimizer.Parser.Predicates;

namespace MathOptimizer.Parser.TokenReaders
{
    /// <summary>
    /// Class which try to read 'NumberToken' from
    /// the spicific position
    /// </summary>
    partial class NumberReader : TokenReader
    {
        public override bool Check(Position pos)
        {
            return Utills.Check(pos, digitPr);
        }
        public override IToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                // Main part of the number
                Utills.MoveWhile(pos, digitPr);

                // Fraction part of the number
                Utills.MoveWhile(pos, numSeparatorPr);
                Utills.MoveWhile(pos, digitPr);

                return new NumberToken(Position.CreateString(start, pos));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");
                ex.Source = "NumberReader";

                throw ex;
            }
        }

        /* Used predicates */
        private readonly DigitPr digitPr = new DigitPr();
        private readonly CommaPr numSeparatorPr = new CommaPr();
    }
}
