namespace MathOptimizer.Parser.Predicates
{
    class NumberTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is INumberToken; }
    }

    class VariableTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is IVariableToken; }
    }

    class ConstantTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is IConstantToken; }
    }

    class BinaryOpTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is IBinaryOpToken; }
    }

    class UnaryOpTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is IUnaryOpToken; }
    }

    class FuncNameTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is IFuncNameToken; }
    }

    class LBracketrTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is ILBracketToken; }
    }

    class RBracketTokenPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is IRBracketToken; }
    }

    class FuncSeparatorPr : IPredicateOf1<IToken>
    {
        public bool Execute(IToken t) { return t is IFuncSeparatorToken; }
    }
}
