using System;

using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.TokenFactories.GeneralPredicates
{
    public class Digit : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return Char.IsDigit(ch);
        }
    }
    public class LBracket : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return ch == '(';
        }
    }
}
