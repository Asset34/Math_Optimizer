using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Predicates;

namespace MathOptimizer.Parser
{
    //
    // Summary:
    //     General utillity class
    static class Utills
    {
        // Position utills
        public static bool Check(Position pos, ICharCheckPredicate pr)
        {
            return pr.Execute(pos.Current);
        }
        public static Position MoveWhile(Position pos, ICharCheckPredicate pr)
        {
            while (!pos.IsEnd && Check(pos, pr))
            {
                pos++;
            }

            return pos;
        } 

        // Symbol utills
    }
}
