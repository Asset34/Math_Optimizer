namespace MathOptimizer.Parser.TokenReaders
{
    partial class IdentifierReader
    {
        private class VariableToken : Token, IVariableToken
        {
            public VariableToken(string value)
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
