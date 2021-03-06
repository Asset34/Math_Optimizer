﻿namespace MathOptimizer.Model.Parser
{
    public interface ITokenVisitor
    {
        void Visit(IVariableToken      t);
        void Visit(IFuncNameToken      t);
        void Visit(IConstantToken      t);
        void Visit(IErrorToken         t);
        void Visit(INumberToken        t);
        void Visit(ILBracketToken      t);
        void Visit(IRBracketToken      t);
        void Visit(IFuncSeparatorToken t);
        void Visit(IUnaryOpToken       t);
        void Visit(IBinaryOpToken      t);
    }
}
