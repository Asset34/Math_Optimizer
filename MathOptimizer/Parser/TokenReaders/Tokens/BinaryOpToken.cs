namespace MathOptimizer.Parser.TokenReaders
{
    partial class OperatorReader
    {
        private class BinaryOpToken : Token, IBinaryOpToken
        {
            public BinaryOpToken(string value)
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
