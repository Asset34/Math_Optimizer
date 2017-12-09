using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser
{
    //
    // Summary:
    //     Represents a utility class for math parser
    static class Utills
    {
        public static bool Check(Position pos, ICharPredicate pr)
        {
            return !pos.IsEnd   && 
                   !pos.IsBegin && 
                   pr.Execute(pos.Current);
        }
        public static bool Check(Stack<IToken> tokens, ITokenPredicate pr)
        {
            return tokens.Count != 0 && pr.Execute(tokens.Peek());
        }
        public static bool Check(IToken t1, Stack<IToken> tokens, ITokenComparePredicate pr)
        {
            return tokens.Count != 0 && pr.Execute(t1, tokens.Peek());
        }

        public static Position     MoveWhile(Position pos, ICharPredicate pr)
        {
            while (Check(pos, pr))
            {
                pos++;
            }

            return pos;
        } 
        public static List<IToken> MoveWhile(Stack<IToken> tokens, ITokenPredicate pr)
        {
            List<IToken> result = new List<IToken>();

            while (Check(tokens, pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }
        public static List<IToken> MoveWhile(IToken t, Stack<IToken> tokens, ITokenComparePredicate pr)
        {
            List<IToken> result = new List<IToken>();

            while (Check(t, tokens, pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }

        public static List<IToken> MoveUntil(Stack<IToken> tokens, ITokenPredicate pr)
        {
            List<IToken> result = new List<IToken>();

            while (!Check(tokens, pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }
    }
}
