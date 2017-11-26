using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Tokens;

namespace MathOptimizer.Parser
{
    public interface ITokenVisitor
    {
        void Visit(IVariableToken     t);
        void Visit(IFunctionNameToken t);
        void Visit(IErrorToken        t);
        void Visit(INumberToken       t);
        void Visit(ILBracketToken     t);
        void Visit(IRBracketToken     t);
        void Visit(IOperatorToken     t);
    }
}
