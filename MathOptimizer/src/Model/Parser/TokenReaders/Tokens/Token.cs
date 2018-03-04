namespace MathOptimizer.Model.Parser.TokenReaders
{
    /// <summary>
    /// Base class for tokens
    /// </summary>
    abstract class Token : IToken
    {
        public Token(string value)
        {
            m_value = value;
        }
        public abstract void Accept(ITokenVisitor visitor);

        public override string ToString()
        {
            return m_value;
        }

        private readonly string m_value;
    }
}
