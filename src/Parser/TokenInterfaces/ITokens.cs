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

    public interface IVariableToken     : IToken                       { }
    public interface IFunctionNameToken : IToken                       { }
    public interface IErrorToken        : IToken                       { }
    public interface INumberToken       : IToken, INumber              { }
    public interface ILBracketToken     : IToken, IPriority            { }
    public interface IRBracketToken     : IToken, IPriority            { }
    public interface IOperatorToken     : IToken, IPriority, IOperator { }
}
