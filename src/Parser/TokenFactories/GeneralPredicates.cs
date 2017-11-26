using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Predicates;

//
// Summary:
//     Contains the general predicate classes for token factories
namespace MathOptimizer.Parser.TokenFactories.GeneralPredicates
{
    public class Digit : ICharCheckPredicate
    {
        public bool Execute(char ch)
        {
            return Char.IsDigit(ch);
        }
    }
    public class Letter : ICharCheckPredicate
    {
        public bool Execute(char ch)
        {
            return Char.IsLetter(ch);
        }
    }
    public class Underscore : ICharCheckPredicate
    {
        public bool Execute(char ch)
        {
            return ch == '_';
        }
    }
}
