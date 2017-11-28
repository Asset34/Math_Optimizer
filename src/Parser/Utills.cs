using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser
{
    //
    // Summary:
    //     General utillity class
    static class Utills
    {
        public static bool Check(Position pos, ICharPredicate pr)
        {
            return pr.Execute(pos.Current);
        }
        public static Position MoveWhile(Position pos, ICharPredicate pr)
        {
            while (!pos.IsEnd && Check(pos, pr))
            {
                pos++;
            }

            return pos;
        } 
    }
}
