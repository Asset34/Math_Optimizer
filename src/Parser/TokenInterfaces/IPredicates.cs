using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser.Interfaces.Predicates
{
    public interface ICharPredicate
    {
        bool Execute(char ch);
    }

    public interface ITokenPredicate
    {
        bool Execute(IToken t);
    }
}
