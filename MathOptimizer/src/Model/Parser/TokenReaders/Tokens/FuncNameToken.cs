namespace MathOptimizer.Model.Parser.TokenReaders
{
    partial class IdentifierReader
    {
        private class FuncNameToken : Token, IFuncNameToken
        {
            public FuncNameToken(string value)
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
