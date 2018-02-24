using System.Collections.Generic;
using System.Linq;

using MathOptimizer.Parser.Predicates;

namespace MathOptimizer.Parser.Handlers
{
    /// <summary>
    /// Handler of math expression which convert input sequence
    /// of tokens to RPN(Reverse Polish notation)
    /// </summary>
    partial class RPNConverter : EmptyTokenVisitor
    {
        public List<IToken> Convert(List<IToken> tokens)
        {
            // Reset handler
            Reset();

            // Handle tokens
            foreach (IToken t in tokens)
            {
                t.Accept(this);
            }

            // Pop the rest of the operators in stack
            PopRemainOperators();

            return m_resultTokens;
        }

        public override void Visit(INumberToken t)
        {
            m_resultTokens.Add(t);
        }
        public override void Visit(IVariableToken t)
        {
            m_resultTokens.Add(t);
        }
        public override void Visit(IConstantToken t)
        {
            m_resultTokens.Add(t);
        }
        public override void Visit(IFuncNameToken t)
        {
            m_operators.Push(t);
        }
        public override void Visit(ILBracketToken t)
        {
            m_operators.Push(t);
        }
        public override void Visit(IRBracketToken t)
        {
            // Get operators of subexpression
            List<IToken> subExpOperators = Utills.MoveUntil(m_operators, m_lbracketPr);

            // Add operators to the result(RPN) list
            m_resultTokens.AddRange(subExpOperators); 

            // Remove left bracket
            m_operators.Pop();

            // Function check
            if (m_operators.Count !=0 && Utills.Check(m_operators, m_funcNamePr))
            {
                m_resultTokens.Add(m_operators.Pop());
            }
        }
        public override void Visit(IFuncSeparatorToken t)
        {
            // Get operators of subexpression
            List<IToken> subExpOperators = Utills.MoveUntil(m_operators, m_lbracketPr);

            // Add operators to the result(RPN) list
            m_resultTokens.AddRange(subExpOperators);
        }
        public override void Visit(IBinaryOpToken t)
        {
            // Get operators with lower or equal priority
            List<IToken> lowOperators = Utills.MoveWhile(t, m_operators, m_priorityPr);

            // Add operators to the result(RPN) list
            m_resultTokens.AddRange(lowOperators);

            m_operators.Push(t);
        }
        public override void Visit(IUnaryOpToken t)
        {
            m_operators.Push(t);
        }

        private void Reset()
        {
            m_operators.Clear();
            m_resultTokens.Clear();
        }
        private void PopRemainOperators()
        {
            m_resultTokens.AddRange(m_operators.ToList());
        }

        /* Used predicates */
        private readonly FuncNameTokenPr m_funcNamePr = new FuncNameTokenPr();
        private readonly LBracketrTokenPr m_lbracketPr = new LBracketrTokenPr();
        private readonly TokenPriorityPr m_priorityPr = new TokenPriorityPr();
        
        private Stack<IToken> m_operators = new Stack<IToken>();
        private List<IToken> m_resultTokens = new List<IToken>();
    }
}
