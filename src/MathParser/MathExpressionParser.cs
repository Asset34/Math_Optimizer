using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer;
using MathOptimizer.Parser.Handlers;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.ExpTree;

namespace MathOptimizer.Parser
{
    class MathExpressionParser
    {
        public static Function Parse(string exp)
        {
            // Handle
            List<IToken> tokens = parser.mathTokenizer.Tokenize(exp);
            parser.mathGrammarScanner.Scann(tokens);
            tokens = parser.mathRPNConverter.Convert(tokens);
            IExpNode expTree = parser.mathASTCreator.Create(tokens);

            // Create function
            string[] variables = parser.mathASTCreator.Variables;
            return new Function(expTree, variables);
        }

        private MathExpressionParser()
        {
        }

        private static readonly MathExpressionParser parser = new MathExpressionParser();

        /* Handlers */
        private readonly MathTokenizer      mathTokenizer      = new MathTokenizer();
        private readonly MathGrammarScanner mathGrammarScanner = new MathGrammarScanner();
        private readonly MathRPNConverter   mathRPNConverter   = new MathRPNConverter();
        private readonly MathASTCreator     mathASTCreator     = new MathASTCreator();
    }
}