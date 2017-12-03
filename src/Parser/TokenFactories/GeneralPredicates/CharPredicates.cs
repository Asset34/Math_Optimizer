using System;

using MathOptimizer.Parser.Interfaces.Predicates;

//
// Summary:
//     Contains the general predicate classes for token factories
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
