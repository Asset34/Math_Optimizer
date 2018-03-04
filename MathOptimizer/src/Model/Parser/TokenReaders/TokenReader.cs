using MathOptimizer.Model.Entities;

namespace MathOptimizer.Model.Parser.TokenReaders
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
