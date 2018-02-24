using System;
using System.Collections.Generic;

using MathOptimizer.Entities;
using MathOptimizer.Parser.Handlers;
using MathOptimizer.Parser.ExpTree;

namespace MathOptimizer.Parser
{
    /// <summary>
    /// Parser of math expressions
    /// </summary>
    class ExpParser
    {
        public Function Parse(string exp)
        {
            // Handle
            List<IToken> tokens = m_tokenizer.Tokenize(exp);
            m_grammarScanner.Scann(tokens);
            tokens = m_RPNConverter.Convert(tokens);
            ExpNode expTree = m_ASTCreator.Create(tokens);

            // Create function
            List<string> variables = m_ASTCreator.Variables;
            return new Function(expTree, variables);
        }

        /* Handlers */
        private readonly Tokenizer m_tokenizer = new Tokenizer();
        private readonly GrammarScanner m_grammarScanner = new GrammarScanner();
        private readonly RPNConverter m_RPNConverter = new RPNConverter();
        private readonly ASTCreator m_ASTCreator = new ASTCreator();
    }
}