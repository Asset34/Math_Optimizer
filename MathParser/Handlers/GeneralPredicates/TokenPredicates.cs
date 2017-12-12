using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser.Handlers.TokenPredicates
{
    class NumberTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(INumberToken t)
        {
            result = true;
        }
    }
    class VariableTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(IVariableToken t)
        {
            result = true;
        }
    }
    class ConstantTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(IConstantToken t)
        {
            result = true;
        }
    }
    class BinaryOpTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(IBinaryOpToken t)
        {
            result = true;
        }
    }
    class UnaryOpTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(IUnaryOpToken t)
        {
            result = true;
        }
    }
    class FunctionNameTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(IFunctionNameToken t)
        {
            result = true;
        }
    }
    class LBracketrTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(ILBracketToken t)
        {
            result = true;
        }
    }
    class RBracketTokenPredicate : EmptyTokenPredicate
    {
        public override void Visit(IRBracketToken t)
        {
            result = true;
        }
    }
    class FuncSeparatorPredicate : EmptyTokenPredicate
    {
        public override void Visit(IFuncSeparatorToken t)
        {
            result = true;
        }
    }
}
