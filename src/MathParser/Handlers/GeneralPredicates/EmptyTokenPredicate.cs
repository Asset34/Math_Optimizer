using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.Handlers.TokenPredicates
{
    abstract class EmptyTokenPredicate : EmptyTokenVisitor, ITokenPredicate
    {
        public bool Execute(IToken t)
        {
            result = false;
            t.Accept(this);
            return result;
        }

        protected bool result;
    }
}
