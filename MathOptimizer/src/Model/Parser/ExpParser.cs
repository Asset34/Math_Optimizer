using System;
using System.Collections.Generic;

using MathOptimizer.Model.Entities;
using MathOptimizer.Model.Parser.Handlers;
using MathOptimizer.Model.Parser.ExpTree;

namespace MathOptimizer.Model.Parser
{
    /// <summary>
    /// Parser of math expressions
    /// </summary>
    class ExpParser
    {
        public Function Parse(string exp)
        {
            if (string.IsNullOrEmpty(exp))
            {
                throw new ArgumentException("Empty expression");
            }

            // Handle
            List<IToken> tokens = m_tokenizer.Tokenize(exp);
            m_grammarScanner.Scann(tokens);
            tokens = m_rpnConverter.Convert(tokens);
            ExpNode expTree = m_astCreator.Create(tokens);

            // Create function
            List<string> variables = m_astCreator.Variables;
            return new Function(expTree, variables);
        }

        /* Handlers */
        private readonly Tokenizer m_tokenizer = new Tokenizer();
        private readonly GrammarScanner m_grammarScanner = new GrammarScanner();
        private readonly RPNConverter m_rpnConverter = new RPNConverter();
        private readonly ASTCreator m_astCreator = new ASTCreator();
    }
}