using System.Collections.Generic;

using MathOptimizer.Model.Parser.ExpTree;

namespace MathOptimizer.Model.Parser.Handlers
{
    /// <summary>
    /// Handler of math expression which build AST(abstract syntax tree)
    /// from sequence of tokens with RPN
    /// </summary>
    class ASTCreator : EmptyTokenVisitor
    {
        public List<string> Variables
        {
            get { return m_variables; }
        }

        public ExpNode Create(List<IToken> tokens)
        {
            // Reset handler
            Reset();

            // Handle tokens
            foreach (IToken t in tokens)
            {
                t.Accept(this);
            }
            
            return m_nodes.Pop();
        }

        public override void Visit(INumberToken t)
        {
            double number = double.Parse(t.ToString());
            m_nodes.Push(new NumberLeaf(number));
        }
        public override void Visit(IVariableToken t)
        {
            /* Add variable */
            if (!m_variables.Contains(t.ToString()))
            {
                m_variables.Add(t.ToString());
            }

            m_nodes.Push(new VariableLeaf(t.ToString()));
        }
        public override void Visit(IConstantToken t)
        {
            double number = Tables.TempConstantsTable[t.ToString()];
            m_nodes.Push(new NumberLeaf(number));
        }
        public override void Visit(IFuncNameToken t)
        {
            // Get number of nessessary arguments
            int n = Tables.FunctionsArgsNumberTable[t.ToString()];

            // Pop arguments
            ExpNode[] arguments = new ExpNode[n];
            for (int i = 0; i < n; i++)
            {
                arguments[i] = m_nodes.Pop();
            }

            m_nodes.Push(Tables.FunctionsExpTable[t.ToString()](arguments));
        }
        public override void Visit(IBinaryOpToken t)    
        {
            ExpNode operand2 = m_nodes.Pop();
            ExpNode operand1 = m_nodes.Pop();

            char op = char.Parse(t.ToString());
            m_nodes.Push(Tables.BinaryOperatorsExpTable[op](operand1, operand2));
        }
        public override void Visit(IUnaryOpToken t)
        {
            ExpNode operand = m_nodes.Peek();
            char op = char.Parse(t.ToString());

            ExpNode unaryOperator = Tables.UnaryOperatorsExpTable[op](operand);
            if (unaryOperator != null)
            {
                m_nodes.Pop();
                m_nodes.Push(unaryOperator);
            } 
        }

        private void Reset()
        {
            m_nodes.Clear();
            m_variables.Clear();
        }
        
        private Stack<ExpNode> m_nodes = new Stack<ExpNode>();
        private List<string> m_variables = new List<string>();
    }
}
