namespace MathOptimizer.Model.Parser.TokenReaders
{
    partial class LBracketReader
    {
        private class LBracketToken : Token, ILBracketToken
        {
            public LBracketToken(string value)
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
