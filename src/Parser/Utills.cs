using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Tokens;
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

        public static bool Check(IToken t, ITokenPredicate pr)
        {
            return pr.Execute(t);
        }
        public static bool Check(IToken t1, IToken t2, ITokenComparePredicate pr)
        {
            return pr.Execute(t1, t2);
        }
        public static List<IToken> MoveWhile(Stack<IToken> tokens, ITokenPredicate pr)
        {
            List<IToken> result = new List<IToken>();

            while (tokens.Count != 0 && Check(tokens.Peek(), pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }
        public static List<IToken> MoveWhile(IToken t, Stack<IToken> tokens, ITokenComparePredicate pr)
        {
            List<IToken> result = new List<IToken>();

            while (tokens.Count != 0 && Check(t, tokens.Peek(), pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }
        public static List<IToken> MoveUntill(Stack<IToken> tokens, ITokenPredicate pr)
        {
            List<IToken> result = new List<IToken>();

            while (tokens.Count != 0 && !Check(tokens.Peek(), pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }
    }
}
