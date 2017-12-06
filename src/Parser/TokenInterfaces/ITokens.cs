namespace MathOptimizer.Parser.Interfaces.Tokens
{
    public interface IToken
    {
        void Accept(ITokenVisitor visitor);
        string ToString();
    }

    public interface IIdentifierToken : IToken { }
    public interface IOperatorToken   : IToken { }

    public interface IErrorToken        : IToken           { }
    public interface INumberToken       : IToken           { }
    public interface ILBracketToken     : IToken           { }
    public interface IRBracketToken     : IToken           { }
    public interface IVariableToken     : IIdentifierToken { }
    public interface IConstantToken     : IIdentifierToken { }
    public interface IFunctionNameToken : IIdentifierToken { }
    public interface IUnaryOpToken      : IOperatorToken   { }
    public interface IBinaryOpToken     : IOperatorToken   { }
    

    
}
