namespace MathOptimizer.Model.Parser.TokenReaders
{
    partial class IdentifierReader
    {
        private class ConstantToken : Token, IConstantToken
        {
            public ConstantToken(string value)
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
