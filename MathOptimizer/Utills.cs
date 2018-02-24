using System;
using System.Collections.Generic;

using MathOptimizer.Entities;
using MathOptimizer.Parser;
using MathOptimizer.Parser.Predicates;

namespace MathOptimizer
{
    /// <summary>
    /// General utility class
    /// </summary>
    static class Utills
    {
        /// <summary>
        /// Ensure that the 1st variable will have a lower
        /// value than the 2nd
        /// </summary>
        /// <param name="a"> 1st variable </param>
        /// <param name="b"> 2nd variable </param>
        public static void Normalization(ref double a, ref double b)
        {
            if (a > b)
            {
                double temp = a;

                a = b;
                b = temp;
            }
        }

        /// <summary>
        /// Defines argument in which the target function takes the min value
        /// </summary>
        /// <param name="f"> target function </param>
        /// <param name="x1"> 1st argument </param>
        /// <param name="x2"> 2nd argument </param>
        /// <param name="x3"> 3rd argument </param>
        /// <returns> min argument </returns>
        public static Vector minArg(Function f, Vector x1, Vector x2, Vector x3)
        {
            Vector min = x1;

            double f1 = f.Evaluate(x1);
            double f2 = f.Evaluate(x2);
            double f3 = f.Evaluate(x3);

            if (f.Evaluate(x2) < f.Evaluate(min))
            {
                min = x2;
            }

            if (f.Evaluate(x3) < f.Evaluate(min))
            {
                min = x3;
            }

            return min;
        }

        /// <summary>
        /// Defines trueness of the specified predicate towards 
        /// char in specified position
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static bool Check(Position pos, IPredicateOf1<char> pr)
        {
            return !pos.IsEnd &&
                   !pos.IsBegin &&
                    pr.Execute(pos.Current);
        }
        /// <summary>
        /// Defines trueness of the specified predicate towards
        /// specified token
        /// </summary>
        /// <param name="tokens"> stack with specified token on top </param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static bool Check(Stack<IToken> tokens, IPredicateOf1<IToken> pr)
        {
            return tokens.Count != 0 && pr.Execute(tokens.Peek());
        }
        /// <summary>
        /// Defines trueness of the specified predicate towards
        /// two specific tokens
        /// </summary>
        /// <param name="t1"> 1st token </param>
        /// <param name="tokens"> stack with 2nd token on top </param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static bool Check(IToken t1, Stack<IToken> tokens, IPredicateOf2<IToken, IToken> pr)
        {
            return tokens.Count != 0 && pr.Execute(t1, tokens.Peek());
        }
        /// <summary>
        /// Move on text data while the specified predicate is true
        /// </summary>
        /// <param name="pos"> start position </param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static Position MoveWhile(Position pos, IPredicateOf1<char> pr)
        {
            while (Check(pos, pr))
            {
                pos++;
            }

            return pos;
        }
        /// <summary>
        /// Move on stack of tokens while the specified predicate is true
        /// </summary>
        /// <param name="tokens"> stack of tokens </param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static List<IToken> MoveWhile(Stack<IToken> tokens, IPredicateOf1<IToken> pr)
        {
            List<IToken> result = new List<IToken>();

            while (Check(tokens, pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }
        /// <summary>
        /// Move on stack of tokens while the specified predicate is true
        /// </summary>
        /// <param name="t"> 1st token </param>
        /// <param name="tokens"> stack with 2nd token </param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static List<IToken> MoveWhile(IToken t, Stack<IToken> tokens, IPredicateOf2<IToken, IToken> pr)
        {
            List<IToken> result = new List<IToken>();

            while (Check(t, tokens, pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }
        /// <summary>
        /// Move on stack of tokens while the specified predicate is false
        /// </summary>
        /// <param name="tokens"> stack with tokens </param>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static List<IToken> MoveUntil(Stack<IToken> tokens, IPredicateOf1<IToken> pr)
        {
            List<IToken> result = new List<IToken>();

            while (!Check(tokens, pr))
            {
                result.Add(tokens.Pop());
            }

            return result;
        }

        /// <summary>
        /// Get names of keys which is missing in specified dictionary
        /// </summary>
        /// <param name="table"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static List<string> GetMissing(Dictionary<string, double> table, List<string> keys)
        {
            List<string> missingKeys = new List<string>();
            foreach (string key in keys)
            {
                if (!table.ContainsKey(key))
                {
                    missingKeys.Add(key);
                }
            }

            return missingKeys;
        }
    }
}
