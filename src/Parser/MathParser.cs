using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Func;
using MathOptimizer.Parser.MathHandlers;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Func.Tree;

namespace MathOptimizer.Parser
{
    class MathParser
    {
        public static Function Parse(string exp)
        {
            // Handle
            List<IToken> tokens = mathParser.mathTokenizer.Tokenize(exp);
            mathParser.mathGrammarScanner.Scann(tokens);
            tokens = mathParser.mathRPNConverter.Convert(tokens);
            IExpNode expTree = mathParser.mathASTCreator.Create(tokens);

            // Create function
            string[] variables = mathParser.mathASTCreator.Variables;
            return new Function(expTree, variables);
        }

        private static readonly MathParser mathParser = new MathParser();

        /* Handlers */
        private readonly MathTokenizer mathTokenizer = new MathTokenizer();
        private readonly MathGrammarScanner mathGrammarScanner = new MathGrammarScanner();
        private readonly MathRPNConverter mathRPNConverter = new MathRPNConverter();
        private readonly MathASTCreator mathASTCreator = new MathASTCreator();
    }
}
