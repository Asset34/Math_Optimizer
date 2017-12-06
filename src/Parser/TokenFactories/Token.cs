using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser.TokenFactories
{
    abstract class Token : IToken
    {
        public Token(string strToken)
        {
            this.value = strToken;
        }

        public abstract void Accept(ITokenVisitor visitor);
        public override string ToString()
        {
            return value;
        }

        private readonly string value;
    }
}
