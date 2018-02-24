using MathOptimizer.Entities;

namespace MathOptimizer.Parser.TokenReaders
{
    /// <summary>
    /// Base class for token readers
    /// </summary>
    abstract class TokenReader
    {
        public abstract bool Check(Position pos);
        public abstract IToken TakeToken(Position pos);
    }
}
