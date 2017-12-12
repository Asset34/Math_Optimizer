using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.TokenFactories.GeneralPredicates
{
    //
    // Summary:
    //     Represents a composite of char predicates:
    //          a1 || a2 || ... || an
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
