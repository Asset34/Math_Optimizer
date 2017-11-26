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
    //     Represents a factory of a function name tokens
    class FunctionNameFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, letterPr) ||
                   Utills.Check(pos, underscorePr);
        }
        public static IFunctionNameToken TakeToken(Position start)
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

                return new FunctionNameToken(Position.MakeString(start, end));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "FunctionNameFactory";
                ex.Data.Add("Position", start.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class FunctionNameToken : IFunctionNameToken
        {
            public FunctionNameToken(string str)
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

        private FunctionNameFactory() { }
    }
}
