using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.TokenPredicates
{
    //
    // Summary:
    //     Represents a base class for the following predicates
    class FalseTokenPredicate : EmptyTokenVisitor, ITokenPredicate
    {
        public bool Execute(IToken t)
        {
            result = false;
            t.Accept(this);
            return result;
        }

        protected bool result;
    }

    class NumberTokenPredicate : FalseTokenPredicate
    {
        public override void Visit(INumberToken t)
        {
            result = true;
        }
    }
    class VariableTokenPredicate : FalseTokenPredicate
    {
        public override void Visit(IVariableToken t)
        {
            result = true;
        }
    }
    class OperatorTokenPredicate : FalseTokenPredicate
    {
        public override void Visit(IOperatorToken t)
        {
            result = true;
        }
    }
    class FunctionNameTokenPredicate : FalseTokenPredicate
    {
        public override void Visit(IFunctionNameToken t)
        {
            result = true;
        }
    }
    class LBracketrTokenPredicate : FalseTokenPredicate
    {
        public override void Visit(ILBracketToken t)
        {
            result = true;
        }
    }
    class RBracketTokenPredicate : FalseTokenPredicate
    {
        public override void Visit(IRBracketToken t)
        {
            result = true;
        }
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
