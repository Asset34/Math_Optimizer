using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces;
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

    class ComparePriorityTokenPredicate : EmptyTokenVisitor, ITokenComparePredicate
    {
        public bool Execute(IToken t1, IToken t2)
        {
            int priority1, priority2;

            t1.Accept(this);
            priority1 = value;

            t2.Accept(this);
            priority2 = value;

            if (priority1 <= priority2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Visit(IOperatorToken t)
        {
            SetPriority(t);
        }
        public override void Visit(ILBracketToken t)
        {
            SetPriority(t);
        }
        public override void Visit(IRBracketToken t)
        {
            SetPriority(t);
        }

        private void SetPriority(IPriority t)
        {
            value = t.Priority;
        }

        private int value;
    }
}
