using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Predicates;

//
// Summary:
//     Contains the general predicate classes for token factories
namespace MathOptimizer.Parser.TokenFactories.CharPredicates
{
    public class Digit : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return Char.IsDigit(ch);
        }
    }
    public class Letter : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return Char.IsLetter(ch);
        }
    }
    public class Underscore : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return ch == '_';
        }
    }

    public class DisjunctionCharPredicate : ICharPredicate
    {
        public bool Execute(char ch)
        {
            foreach (ICharPredicate pr in Predicates)
            {
                if (pr.Execute(ch))
                {
                    return true;
                }
            }

            return false;
        }

        public List<ICharPredicate> Predicates
        {
            get { return predicates; }
        }

        private List<ICharPredicate> predicates = new List<ICharPredicate>();
    }
}
