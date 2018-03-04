namespace MathOptimizer.Model.Parser.TokenReaders
{
    partial class FuncSeparatorReader
    {
        private class FunctionSeparatorToken : Token, IFuncSeparatorToken
        {
            public FunctionSeparatorToken(string value)
                : base(value)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
    }
}
