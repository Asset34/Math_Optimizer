using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Tokens;

namespace MathOptimizer.Parser.Interfaces.Predicates
{
    /* Char predicate interfaces */
    public interface ICharPredicate
    {
        bool Execute(char ch);
    }

    /* Token predicate interfaces */
    public interface ITokenPredicate
    {
        bool Execute(IToken t);
    }
    public interface ITokenComparePredicate
    {
        bool Execute(IToken t1, IToken t2);
    }
}
