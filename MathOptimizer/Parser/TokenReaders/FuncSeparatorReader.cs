using System;

using MathOptimizer.Entities;
using MathOptimizer.Parser.Predicates;

namespace MathOptimizer.Parser.TokenReaders
{
    /// <summary>
    /// Class which try to read 'FuncSeparatorToken' from
    /// the spicific position
    /// </summary>
    partial class FuncSeparatorReader : TokenReader
    {
        public override bool Check(Position pos)
        {
            return Utills.Check(pos, semicolonPr);
        }
        public override IToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);
                pos++;

                return new FunctionSeparatorToken(start.Current.ToString());
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");
                ex.Source = "LBracketReader";

                throw ex;
            }
        }

        /* Used predicates */
        private readonly SemicolonPr semicolonPr = new SemicolonPr();
    }
}
