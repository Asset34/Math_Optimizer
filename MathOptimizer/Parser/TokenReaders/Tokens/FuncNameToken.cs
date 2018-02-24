namespace MathOptimizer.Parser.TokenReaders
{
    partial class IdentifierReader
    {
        private class FunctionNameToken : Token, IFuncNameToken
        {
            public FunctionNameToken(string value)
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
