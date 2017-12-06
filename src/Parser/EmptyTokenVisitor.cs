using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser
{
    class EmptyTokenVisitor : ITokenVisitor
    {
        public virtual void Visit(IVariableToken     t)  { }
        public virtual void Visit(IFunctionNameToken t)  { }
        public virtual void Visit(IConstantToken     t)  { }
        public virtual void Visit(IErrorToken        t)  { }
        public virtual void Visit(INumberToken       t)  { }
        public virtual void Visit(ILBracketToken     t)  { }
        public virtual void Visit(IRBracketToken     t)  { }
        public virtual void Visit(IFuncSeparatorToken t) { }
        public virtual void Visit(IUnaryOpToken      t)  { }
        public virtual void Visit(IBinaryOpToken     t)  { }
    }
}