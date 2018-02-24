using System;
using System.Collections.Generic;

using MathOptimizer.Entities;
using MathOptimizer.Parser.TokenReaders;

namespace MathOptimizer.Parser.Handlers
{
    /// <summary>
    /// Handler of math expression which split expression to tokens
    /// </summary>
    class Tokenizer
    {
        public List<IToken> Tokenize(string exp)
        {
            // Preprocessing
            exp = Preprocess(exp);

            // Tokenization
            List<IToken> tokens = new List<IToken>();
            List<IToken> errorTokens = new List<IToken>();
            Position pos = new Position(exp);
            while (!pos.IsEnd)
            {
                foreach (TokenReader reader in m_readers)
                {
                    if (reader.Check(pos))
                    {
                        tokens.Add(reader.TakeToken(pos));
                        break;
                    }
                }

                if (m_errorReader.Check(pos) && !pos.IsEnd)
                {
                    errorTokens.Add(m_errorReader.TakeToken(pos));
                }
            }

            // Handle errors
            HandleErrors(errorTokens);

            return tokens;
        }
        
        private string Preprocess(string exp)
        {
            return exp.Replace(" ", string.Empty);
        }
        private void HandleErrors(List<IToken> errorTokens)
        {
            if (errorTokens.Count > 0)
            {
                Exception ex = new Exception("Invalid expression");
                ex.Source = "ExpParser(Tokenizer)";
                List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
                foreach (IToken t in errorTokens)
                {
                    errors.Add(new KeyValuePair<string, string>(t.ToString(), "Undefined token"));
                }
                ex.Data.Add("Errors", errors);

                throw ex;
            }
        }

        private readonly List<TokenReader> m_readers = new List<TokenReader>()
        {
            new NumberReader(),
            new IdentifierReader(),
            new OperatorReader(),
            new FuncSeparatorReader(),
            new LBracketReader(),
            new RBracketReader()
        };
        private readonly ErrorReader m_errorReader = new ErrorReader();
    }
}
