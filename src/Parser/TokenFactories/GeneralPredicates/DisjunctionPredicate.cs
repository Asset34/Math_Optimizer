using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.TokenFactories.GeneralPredicates
{
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
