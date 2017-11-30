using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser.Interfaces.Tokens
{
    public interface IToken
    {
        void Accept(ITokenVisitor visitor);
        string ToString();
    }

    public interface IIdentifierToken : IToken { };
    public interface IOperatorToken : IToken, IOperator { }

    public interface INumberToken       : IToken, INumber           { }
    public interface ILBracketToken     : IToken, IPriority         { }
    public interface IRBracketToken     : IToken, IPriority         { }
    public interface IErrorToken        : IToken                    { }
    public interface IVariableToken     : IIdentifierToken          { }
    public interface IFunctionNameToken : IIdentifierToken          { }
    public interface IUnaryOpToken      : IOperatorToken, IPriority { }
    public interface IBinaryOpToken     : IOperatorToken, IPriority { }
    

    
}
