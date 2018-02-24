using MathOptimizer.Parser.Predicates;

namespace MathOptimizer.Parser.Handlers
{
    partial class RPNConverter
    {
        private class TokenPriorityPr : EmptyTokenVisitor, IPredicateOf2<IToken, IToken>
        {
            public bool Execute(IToken t1, IToken t2)
            {
                int priority1, priority2;

                // Get priority of t1
                t1.Accept(this);
                priority1 = m_value;

                // Get priority of t2
                t2.Accept(this);
                priority2 = m_value;

                // Compare
                if (priority1 <= priority2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override void Visit(IBinaryOpToken t)
            {
                char op = char.Parse(t.ToString());
                SetPriority(Tables.BinaryOperatorsPriorityTable[op]);
            }
            public override void Visit(IUnaryOpToken t)
            {
                char op = char.Parse(t.ToString());
                SetPriority(Tables.UnaryOperatorsPriorityTable[op]);
            }
            public override void Visit(ILBracketToken t)
            {
                SetPriority(0);
            }
            public override void Visit(IRBracketToken t)
            {
                SetPriority(0);
            }

            private void SetPriority(int priority)
            {
                m_value = priority;
            }

            private int m_value;
        }
    }
}
