namespace MathOptimizer.Parser.TokenReaders
{
    partial class RBracketReader
    {
        private class RBracketToken : Token, IRBracketToken
        {
            public RBracketToken(string value)
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
