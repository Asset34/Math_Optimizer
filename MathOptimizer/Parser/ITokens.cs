namespace MathOptimizer.Parser
{
    public interface IToken
    {
        void Accept(ITokenVisitor visitor);
        string ToString();
    }

    public interface IErrorToken         : IToken { }
    public interface INumberToken        : IToken { }
    public interface ILBracketToken      : IToken { }
    public interface IRBracketToken      : IToken { }
    public interface IFuncSeparatorToken : IToken { }
    public interface IVariableToken      : IToken { }
    public interface IConstantToken      : IToken { }
    public interface IFuncNameToken      : IToken { }
    public interface IUnaryOpToken       : IToken { }
    public interface IBinaryOpToken      : IToken { }
}
