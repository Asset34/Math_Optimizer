using System;
using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.TokenFactories;

namespace MathOptimizer.Parser.Handlers
{
    //
    // Summary:
    //     Represents a part of the Parser which implement tokenization
    //     of the input math expression
    class MathTokenizer
    {
        public List<IToken> Tokenize(string exp)
        {
            Preprocess(ref exp);

            /* Tokenization */
            List<IToken> tokens = new List<IToken>();
            List<IToken> errorTokens = new List<IToken>();
            bool errorFlag = false;

            Position pos = new Position(exp);
            while (!pos.IsEnd)
            {
                if (numberFactory.Check(pos))
                {
                    tokens.Add(numberFactory.TakeToken(pos));
                }
                else if(identifierFactory.Check(pos))
                {
                    tokens.Add(identifierFactory.TakeToken(pos));
                }
                else if (operatorFactory.Check(pos))
                {
                    tokens.Add(operatorFactory.TakeToken(pos));
                }
                else if (lbracketFactory.Check(pos))
                {
                    tokens.Add(lbracketFactory.TakeToken(pos));
                }
                else if (rbracketFactory.Check(pos))
                {
                    tokens.Add(rbracketFactory.TakeToken(pos));
                }
                else if (funcSeparatorFactory.Check(pos))
                {
                    tokens.Add(funcSeparatorFactory.TakeToken(pos));
                }
                // Error
                else
                {
                    errorFlag = true;
                    errorTokens.Add(errorFactory.TakeToken(pos));
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
        
        private void Preprocess(ref string exp)
        {
            //Remove whitespace characters
            exp = exp.Replace(" ", String.Empty);
        }

        /* Token factories */
        private readonly NumberFactory numberFactory = new NumberFactory();
        private readonly IdentifierFactory identifierFactory = new IdentifierFactory();
        private readonly OperatorFactory operatorFactory = new OperatorFactory();
        private readonly FunctionSeparatorFactory funcSeparatorFactory = new FunctionSeparatorFactory();
        private readonly LBracketFactory lbracketFactory = new LBracketFactory();
        private readonly RBracketFactory rbracketFactory = new RBracketFactory();
        private readonly ErrorFactory errorFactory = new ErrorFactory();
    }
}
