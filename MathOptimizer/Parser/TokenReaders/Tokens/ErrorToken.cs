namespace MathOptimizer.Parser.TokenReaders
{
    partial class ErrorReader
    {
        private class ErrorToken : Token, IErrorToken
        {
            public ErrorToken(string value)
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
