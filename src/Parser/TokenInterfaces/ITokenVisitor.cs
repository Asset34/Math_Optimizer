using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser.Interfaces
{
    public interface ITokenVisitor
    {
        void Visit(IVariableToken     t);
        void Visit(IFunctionNameToken t);
        void Visit(IConstantToken          t);
        void Visit(IErrorToken        t);
        void Visit(INumberToken       t);
        void Visit(ILBracketToken     t);
        void Visit(IRBracketToken     t);
        void Visit(IUnaryOpToken      t);
        void Visit(IBinaryOpToken     t);
    }
}
