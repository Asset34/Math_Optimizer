namespace MathOptimizer.Parser.TokenReaders
{
    partial class OperatorReader
    {
        private class UnaryOpToken : Token, IUnaryOpToken
        {
            public UnaryOpToken(string value)
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
