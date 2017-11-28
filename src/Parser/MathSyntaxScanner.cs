using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser
{
    class MathSyntaxScanner : ITokenVisitor
    {
        public void Scann(List<IToken> tokens)
        {
            /* Visit all tokens */
            foreach (IToken t in tokens)
            {
                t.Accept(this);
            }
        }

        public void Visit(IVariableToken t)
        {

        }
        public void Visit(IFunctionNameToken t)
        {

        }
        public void Visit(IErrorToken t)
        {

        }
        public void Visit(INumberToken t)
        {

        }
        public void Visit(ILBracketToken t)
        {

        }
        public void Visit(IRBracketToken t)
        {

        }
        public void Visit(IOperatorToken t)
        {

        }
    }
}
