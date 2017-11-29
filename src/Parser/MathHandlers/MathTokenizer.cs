using System;
using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.TokenFactories;

namespace MathOptimizer.Parser.MathHandlers
{
    //
    // Summary:
    //     Represents a math expressions tokenizer
    class MathTokenizer
    {
        public static List<IToken> Tokenize(string exp)
        {
            Preprocess(ref exp);

            /* Tokenization */

            List<IToken> tokens = new List<IToken>();
            List<IToken> errorTokens = new List<IToken>();
            bool errorFlag = false;

            Position pos = new Position(exp);
            while (!pos.IsEnd)
            {
                if (NumberFactory.Check(pos))
                {
                    tokens.Add(NumberFactory.TakeToken(pos));
                }
                else if(IdentifierFactory.Check(pos))
                {
                    tokens.Add(IdentifierFactory.TakeToken(pos));
                }
                else if (OperatorFactory.Check(pos))
                {
                    tokens.Add(OperatorFactory.TakeToken(pos));
                }
                else if (LBracketFactory.Check(pos))
                {
                    tokens.Add(LBracketFactory.TakeToken(pos));
                }
                else if (RBracketFactory.Check(pos))
                {
                    tokens.Add(RBracketFactory.TakeToken(pos));
                }
                // Error
                else
                {
                    errorFlag = true;
                    errorTokens.Add(ErrorFactory.TakeToken(pos));
                }
            }

            /* Handle errors */
            if (errorFlag)
            {
                Exception ex = new Exception("Cannot identify the lexemes");

                ex.Source = "MathTokenizer";

                int i = 1;
                foreach (IToken t in errorTokens)
                {
                    ex.Data.Add(i, t.ToString());
                    i++;
                }

                throw ex;
            }

            return tokens;
        }

        //
        // Summary:
        //     Performs preprocessing the string of the expression:
        //      - Remove all whitespace(' ') characters
        private static void Preprocess(ref string exp)
        {
            //Remove whitespace characters
            exp = exp.Replace(" ", String.Empty);
        }
    }
}
