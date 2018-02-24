using System;

using MathOptimizer.Entities;
using MathOptimizer.Parser.Predicates;

namespace MathOptimizer.Parser.TokenReaders
{
    /// <summary>
    /// Class which try to read 'UnaryOpToken' and 'BinaryOpToken' from
    /// the spicific position
    /// </summary>
    partial class OperatorReader : TokenReader
    {
        public override bool Check(Position pos)
        {
            return Utills.Check(pos, opPr);
        }
        public override IToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);
                pos++;

                string strToken = start.Current.ToString();
                
                if (CheckUnaryOp(start))
                {
                    return new UnaryOpToken(strToken);
                }
                else
                {
                    return new BinaryOpToken(strToken);
                }
            }   
            else
            {
                Exception ex = new Exception("Cannot take the token");
                ex.Source = "OperatorReader";

                throw ex;
            }    
        }

        private bool CheckUnaryOp(Position pos)
        {
            Position prevPos = pos - 1;

            // If <UnaryOp> is a first character
            if (prevPos.IsBegin)
            {
                return true;
            }

            // If <UnaryOp> located after the left bracket ')'
            if (Utills.Check(pos - 1, lbracketPr) &&
                Tables.UnaryOperatorsPriorityTable.ContainsKey(pos.Current))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Used predicates */
        private readonly OperatorPr opPr = new OperatorPr();
        private readonly LBracketPr lbracketPr = new LBracketPr();
    }
}
