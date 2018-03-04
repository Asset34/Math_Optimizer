using System;

using MathOptimizer.Model.Entities;
using MathOptimizer.Model.Parser.Predicates;

namespace MathOptimizer.Model.Parser.TokenReaders
{
    /// <summary>
    /// Class which try to read 'LbracketToken' from
    /// the spicific position
    /// </summary>
    partial class LBracketReader : TokenReader
    {
        public override bool Check(Position pos)
        {
            return Utills.Check(pos, lbracketPr);
        }
        public override IToken TakeToken(Position pos)
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
                ex.Source = "LBracketReader";

                throw ex;
            }
        }

        /* Used predicates */
        private readonly LBracketPr lbracketPr = new LBracketPr();
    }
}
