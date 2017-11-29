using System;
using System.Collections.Generic;
using System.Linq;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;
using MathOptimizer.Parser.MathHandlers.TokenPredicates;

namespace MathOptimizer.Parser.MathHandlers
{
    class MathRPNConverter : ITokenVisitor
    {
        public static List<IToken> Convert(List<IToken> tokens)
        {
            /* Handle tokens */
            foreach (IToken t in tokens)
            {
                t.Accept(mathRPNConverter);
            }

            /* Pop the rest of the operators in stack */
            mathRPNConverter.PopRemainOperators();

            return mathRPNConverter.resultTokens;
        }

        public void Visit(INumberToken t)
        {
            resultTokens.Add(t);
        }
        public void Visit(IVariableToken t)
        {
            resultTokens.Add(t);
        }
        public void Visit(IFunctionNameToken t)
        {
            operators.Push(t);
        }
        public void Visit(ILBracketToken t)
        {
            operators.Push(t);
        }
        public void Visit(IRBracketToken t)
        {
            // Get operators of subexpression
            List<IToken> subExpOperators = Utills.MoveUntill(operators, lBracketPr);
            resultTokens.AddRange(subExpOperators);

            // Remove left bracket
            operators.Pop();

            // Function check
            if (Utills.Check(operators.Peek(), functionNamePr))
            {
                resultTokens.Add(operators.Pop());
            }
        }
        public void Visit(IOperatorToken t)
        {
            // Get operators with lower or equal priority
            List<IToken> lowOperators = Utills.MoveWhile(t, operators, comparePriorityPr);
            resultTokens.AddRange(lowOperators);

            operators.Push(t);
        }

        public void Visit(IErrorToken t)
        {
            /* TODO */
        }

        private void PopRemainOperators()
        {
            resultTokens.AddRange(operators.ToList());
        }

        /* Local predicate classes */
        private class ComparePriorityTokenPredicate : EmptyTokenVisitor, ITokenComparePredicate
        {
            public bool Execute(IToken t1, IToken t2)
            {
                int priority1, priority2;

                // Get priority of t1
                t1.Accept(this);
                priority1 = value;

                // Get priority of t2
                t2.Accept(this);
                priority2 = value;

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

            public override void Visit(IOperatorToken t)
            {
                SetPriority(t);
            }
            public override void Visit(ILBracketToken t)
            {
                SetPriority(t);
            }
            public override void Visit(IRBracketToken t)
            {
                SetPriority(t);
            }

            private void SetPriority(IPriority t)
            {
                value = t.Priority;
            }

            private int value;
        }

        /* Used predicates */
        private static readonly FunctionNameTokenPredicate functionNamePr = new FunctionNameTokenPredicate();
        private static readonly LBracketrTokenPredicate lBracketPr = new LBracketrTokenPredicate();
        private static readonly ComparePriorityTokenPredicate comparePriorityPr = new ComparePriorityTokenPredicate();

        private static readonly MathRPNConverter mathRPNConverter = new MathRPNConverter();

        private Stack<IToken> operators = new Stack<IToken>();
        private List<IToken> resultTokens = new List<IToken>();
    }
}
