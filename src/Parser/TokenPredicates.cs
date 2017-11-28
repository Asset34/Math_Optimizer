using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.TokenPredicates
{
    class TokenPredicate<TToken> : EmptyTokenVisitor, ITokenPredicate
    {
        public bool Execute(IToken t)
        {
            result = false;
            t.Accept(this);
            return result;
        }

        public void Visit(TToken t)
        {
            result = true;
        }

        private bool result;
    }

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
