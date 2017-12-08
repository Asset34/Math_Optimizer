using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.ExpTree;
using MathOptimizer.Func;

namespace MathOptimizer.Parser.MathHandlers
{
    //
    // Summary:
    //     Represents a part of the Parser which build 
    //     AST(abstract syntax tree)
    class MathASTCreator : EmptyTokenVisitor
    {
        public IExpNode Create(List<IToken> tokens)
        {
            // Reset handler
            Reset();

            // Handle tokens
            foreach (IToken t in tokens)
            {
                t.Accept(this);
            }
            
            return expTree.Pop();
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
            // Get number of nessessary arguments
            int n = Tables.FunctionsArgsNumberTable[t.ToString()];

            // Pop arguments
            IExpNode[] arguments = new IExpNode[n];
            for (int i = 0; i < n; i++)
            {
                arguments[i] = expTree.Pop();
            }
            
            expTree.Push(Tables.FunctionsExpTable[t.ToString()](arguments));
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

        public string[] Variables
        {
            get { return variables.ToArray(); }
        }

        private void Reset()
        {
            expTree.Clear();
            variables.Clear();
        }
        
        private Stack<IExpNode> expTree = new Stack<IExpNode>();
        private List<string> variables = new List<string>();
    }
}
