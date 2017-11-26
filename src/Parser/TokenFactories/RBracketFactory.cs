using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Tokens;
using MathOptimizer.Parser.Predicates;
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
        public static IRBracketToken TakeToken(Position start)
        {
            if (Check(start))
            {
                Position end = start + 1;

                string strToken = Position.MakeString(start, end);
                int priority = 0;

                return new RBracketToken(strToken, priority);
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "LBracketFactory";
                ex.Data.Add("Position", start.Number);

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
