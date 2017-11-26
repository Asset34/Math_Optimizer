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
    //     Represents a factory of a number tokens
    class NumberFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, digitPr);
        }
        public static INumberToken TakeToken(Position start)
        {
            if (Check(start))
            {
                Position end = start;

                // Main part of the number
                end = Utills.MoveWhile(end, digitPr);
                // Fraction part of the number
                end = Utills.MoveWhile(end, numSeparatorPr);
                end = Utills.MoveWhile(end, digitPr);

                return new NumberToken(Position.MakeString(start, end));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "NumberFactory";
                ex.Data.Add("Position", start.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class NumberToken : INumberToken
        {
            public NumberToken(string str)
            {
                this.value = str;
            }
            public void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
            public override string ToString()
            {
                return value.ToString();
            }

            public double Number
            {
                get
                {
                    return double.Parse(value);
                }
            }

            private readonly string value;
        }

        /* Local predicate classes */       
        private class NumberSeparator : ICharCheckPredicate
        {
            public bool Execute(char ch)
            {
                return ch == ',';
            }
        }

        /* Used predicates */
        private static readonly Digit digitPr = new Digit();
        private static readonly NumberSeparator numSeparatorPr = new NumberSeparator();
        
        private NumberFactory() {}
    }
}
