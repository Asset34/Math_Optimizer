using System;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a number tokens
    //
    // Formal Grammar:
    //     <Number> ::= <Digit> | <Digit> ',' <Digit>
    //     <Digit>  ::= '0' | ... | '9'
    class NumberFactory
    {
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, digitPr);
        }
        public static INumberToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                // Main part of the number
                Utills.MoveWhile(pos, digitPr);
                // Fraction part of the number
                Utills.MoveWhile(pos, numSeparatorPr);
                Utills.MoveWhile(pos, digitPr);

                return new NumberToken(Position.MakeString(start, pos));
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "NumberFactory";
                ex.Data.Add("Position", pos.Number);

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
        private class NumberSeparator : ICharPredicate
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
