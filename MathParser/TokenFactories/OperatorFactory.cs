using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a operator tokens
    //
    // Formal Grammar:
    //     <BinaryOp> ::= '+' | .. | '^'
    //     <UnaryOp>  ::= '-' | '+'
    class OperatorFactory
    {
        public bool Check(Position pos)
        {
            return Utills.Check(pos, operatorPr);
        }
        public IOperatorToken TakeToken(Position pos)
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

                ex.Source = "OperatorFactory";
                ex.Data.Add("Position", pos.Number);

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

        /* Produced token */
        private class BinaryOpToken : Token, IBinaryOpToken
        {
            public BinaryOpToken(string strToken)
                :base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        private class UnaryOpToken : Token, IUnaryOpToken
        {
            public UnaryOpToken(string strToken)
                :base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        
        /* Used predicates */
        private readonly Operator operatorPr = new Operator();
        private readonly LBracket lbracketPr = new LBracket();
    }
}
