using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Predicates;

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

    public class DisjunctionPredicate : ICharCheckPredicate
    {
        public bool Execute(char ch)
        {
            foreach (ICharCheckPredicate pr in Predicates)
            {
                if (pr.Execute(ch))
                {
                    return true;
                }
            }

            return false;
        }

        public List<ICharCheckPredicate> Predicates
        {
            get { return predicates; }
        }

        private List<ICharCheckPredicate> predicates = new List<ICharCheckPredicate>();
    }
}
