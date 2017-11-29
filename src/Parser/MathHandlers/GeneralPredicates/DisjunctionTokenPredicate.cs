using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.MathHandlers.TokenPredicates
{
    class DisjunctionTokenPredicate : ITokenPredicate
    {
        public bool Execute(IToken t)
        {
            foreach (ITokenPredicate pr in Predicates)
            {
                if (pr.Execute(t))
                {
                    return true;
                }
            }

            return false;
        }

        public List<ITokenPredicate> Predicates
        {
            get { return predicates; }
        }

        private List<ITokenPredicate> predicates = new List<ITokenPredicate>();
    }
}
