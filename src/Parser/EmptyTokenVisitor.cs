﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser
{
    class EmptyTokenVisitor : ITokenVisitor
    {
        public virtual void Visit(IVariableToken t)     { }
        public virtual void Visit(IFunctionNameToken t) { }
        public virtual void Visit(IErrorToken t)        { }
        public virtual void Visit(INumberToken t)       { }
        public virtual void Visit(ILBracketToken t)     { }
        public virtual void Visit(IRBracketToken t)     { }
        public virtual void Visit(IOperatorToken t)     { }
    }
}