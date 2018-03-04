namespace MathOptimizer.Model.Parser.TokenReaders
{
    partial class NumberReader
    {
        private class NumberToken : Token, INumberToken
        {
            public NumberToken(string value)
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
