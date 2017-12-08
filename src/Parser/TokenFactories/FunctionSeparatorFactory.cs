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
    //
    // Summary:
    //     Represents a factory of a function separator tokens
    //
    // Formal Grammar:
    //     <FuncSeparator> ::= ';'
    class FunctionSeparatorFactory
    {
        public bool Check(Position pos)
        {
            return Utills.Check(pos, semicolonPr);
        }
        public IFuncSeparatorToken TakeToken(Position pos)
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

                ex.Source = "LBracketFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class FunctionSeparatorToken : Token, IFuncSeparatorToken
        {
            public FunctionSeparatorToken(string strToken)
                : base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        /* Local predicates */
        private class Semicolon : ICharPredicate
        {
            public bool Execute(char ch)
            {
                return ch == ';';
            }
        }

        /* Used predicates */
        private readonly Semicolon semicolonPr = new Semicolon();
    }
}
