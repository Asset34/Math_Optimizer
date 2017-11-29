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
    //     Represents a factory of a variable tokens
    class VariableFactory
    {
        static VariableFactory()
        {
            // Build a predicate for start of the variable
            beginVariablePr.Predicates.Add(new Underscore());
            beginVariablePr.Predicates.Add(new Letter());

            // Build a predicate for other part of the variable
            variablePr.Predicates.Add(beginVariablePr);
            variablePr.Predicates.Add(new Digit());
        }
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, beginVariablePr);
        }
        public static IVariableToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                Utills.MoveWhile(pos, variablePr);

                return new VariableToken(Position.MakeString(start, pos));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "VariableFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class VariableToken : IVariableToken
        {
            public VariableToken(string str)
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

        /* Used predicates */
        private static DisjunctionCharPredicate beginVariablePr = new DisjunctionCharPredicate();
        private static DisjunctionCharPredicate variablePr = new DisjunctionCharPredicate();

        private VariableFactory() {}
    }
}
