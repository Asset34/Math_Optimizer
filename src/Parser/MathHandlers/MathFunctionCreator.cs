using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Func.Tree;
using MathOptimizer.Parser.Func;

namespace MathOptimizer.Parser.MathHandlers
{
    //
    // Summary:
    //     Represents a part of the Parser which build 
    //     AST(abstract syntax tree)
    class MathFunctionCreator : EmptyTokenVisitor
    {
        public static Function Create(List<IToken> tokens)
        {
            // Reset handler
            mathFunctionCreator.Reset();

            // Handle tokens
            foreach (IToken t in tokens)
            {
                t.Accept(mathFunctionCreator);
            }

            // Create function
            IExpNode expTree = mathFunctionCreator.expTree.Pop();
            string[] variables = mathFunctionCreator.variables.ToArray();

            return new Function(expTree, variables);
        }

        public override void Visit(INumberToken t)
        {
            double number = double.Parse(t.ToString());
            expTree.Push(new NumberExp(number));
        }
        public override void Visit(IVariableToken t)
        {
            /* Add variable */
            if (!variables.Contains(t.ToString()))
            {
                variables.Add(t.ToString());
            }

            expTree.Push(new VariableExp(t.ToString()));
        }
        public override void Visit(IConstantToken t)
        {
            double number = Tables.ConstantsTable[t.ToString()];
            expTree.Push(new NumberExp(number));
        }
        public override void Visit(IFunctionNameToken t)
        {
            IExpNode operand = expTree.Pop();

            expTree.Push(Tables.FunctionsExpTable[t.ToString()](operand));
        }
        public override void Visit(IBinaryOpToken t)
        {
            IExpNode operand2 = expTree.Pop();
            IExpNode operand1 = expTree.Pop();

            char op = char.Parse(t.ToString());
            expTree.Push(Tables.BinaryOperatorsExpTable[op](operand1, operand2));
        }
        public override void Visit(IUnaryOpToken t)
        {
            IExpNode operand = expTree.Peek();

            char op = char.Parse(t.ToString());
            IExpNode unaryOperator = Tables.UnaryOperatorsExpTable[op](operand);

            if (unaryOperator != null)
            {
                expTree.Pop();
                expTree.Push(unaryOperator);
            } 
        }

        private void Reset()
        {
            expTree.Clear();
            variables.Clear();
        }

        /* Handler */
        private static MathFunctionCreator mathFunctionCreator = new MathFunctionCreator();

        private Stack<IExpNode> expTree = new Stack<IExpNode>();
        private List<string> variables = new List<string>();
    }
}
