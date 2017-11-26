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
    //     Represents a factory of a variable tokens
    class VariableFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, letterPr) ||
                   Utills.Check(pos, underscorePr);
        }
        public static IVariableToken TakeToken(Position start)
        {
            if (Check(start))
            {
                Position end = start;

                while (Check(end))
                {
                    end = Utills.MoveWhile(end, digitPr);
                    end = Utills.MoveWhile(end, underscorePr);
                    end = Utills.MoveWhile(end, letterPr);
                }

                return new VariableToken(Position.MakeString(start, end));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "VariableFactory";
                ex.Data.Add("Position", start.Number);

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
        private static readonly Digit digitPr = new Digit();
        private static readonly Underscore underscorePr = new Underscore();
        private static readonly Letter letterPr = new Letter();

        private VariableFactory() {}
    }
}
