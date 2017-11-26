using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser.Predicates
{
    public interface ICharCheckPredicate
    {
        bool Execute(char c);
    }
}
