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
    //     Represents a factory of a right bracket tokens
    class RBracketFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, rbracketPr);
        }
        public static IRBracketToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                pos++;

                return new RBracketToken(Position.MakeString(start, pos), 0);
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
        private class RBracketToken : IRBracketToken
        {
            public RBracketToken(string str, int priority)
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

            public int Priority { get; }

            private readonly string value;
        }

        /* Local predicate classes */
        public class RBracket : ICharCheckPredicate
        {
            public bool Execute(char ch)
            {
                return ch == ')';
            }
        }

        /* Used predicates */
        private static readonly RBracket rbracketPr = new RBracket();

        private RBracketFactory() { }
    }
}
