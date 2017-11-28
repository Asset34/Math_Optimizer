using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.TokenPredicates;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser
{
    class MathSyntaxScanner : ITokenVisitor
    {
        public MathSyntaxScanner()
        {
            /* Build Finite-state machine */

            // Terminal symbols
            ITokenPredicate variable     = new TokenPredicate<IVariableToken>    ();
            ITokenPredicate number       = new TokenPredicate<INumberToken>      ();
            ITokenPredicate op           = new TokenPredicate<IOperatorToken>    ();
            ITokenPredicate functionName = new TokenPredicate<IFunctionNameToken>();
            ITokenPredicate lBracket     = new TokenPredicate<ILBracketToken>    ();
            ITokenPredicate rBracket     = new TokenPredicate<IRBracketToken>    ();

            DisjunctionTokenPredicate disjunctionPr = new DisjunctionTokenPredicate();

            // MathExp
            disjunctionPr.Predicates.Add(variable);
            disjunctionPr.Predicates.Add(number);
            disjunctionPr.Predicates.Add(functionName);
            disjunctionPr.Predicates.Add(lBracket);

            edgesMathExp = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // Variable
            disjunctionPr.Predicates.Add(op);
            disjunctionPr.Predicates.Add(rBracket);

            edgesVariable = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // RBracket
            disjunctionPr.Predicates.Add(op);
            disjunctionPr.Predicates.Add(rBracket);

            edgesRBracket = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // Number
            edgesNumber = edgesVariable;

            // Operator
            edgesOperator = edgesMathExp;

            // LBracket
            edgesLBracket = edgesMathExp;

            // FunctionName
            edgesFunctionName = lBracket;

            /* Set start edges */
            edgesCurrent = edgesMathExp;
        }
        public void Scann(List<IToken> tokens)
        {
            foreach (IToken t in tokens)
            {
                t.Accept(this);
            }
        }

        public void Visit(IVariableToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesVariable;
            }
            else
            {
                Exception ex = new Exception("Invalid expression");

                ex.Source = "MathSyntaxScanner";
                ex.Data.Add("Last token", t);

                throw ex;
            }
        }
        public void Visit(IFunctionNameToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesFunctionName;
            }
            else
            {
                Exception ex = new Exception("Invalid expression");

                ex.Source = "MathSyntaxScanner";
                ex.Data.Add("Last token", t.ToString());

                throw ex;
            }
        }
        public void Visit(IErrorToken t)
        {
            /* TODO */
        }
        public void Visit(INumberToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesNumber;
            }
            else
            {
                Exception ex = new Exception("Invalid expression");

                ex.Source = "MathSyntaxScanner";
                ex.Data.Add("Last token", t);

                throw ex;
            }
        }
        public void Visit(ILBracketToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesLBracket;
            }
            else
            {
                Exception ex = new Exception("Invalid expression");

                ex.Source = "MathSyntaxScanner";
                ex.Data.Add("Last token", t);

                throw ex;
            }
        }
        public void Visit(IRBracketToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesRBracket;
            }
            else
            {
                Exception ex = new Exception("Invalid expression");

                ex.Source = "MathSyntaxScanner";
                ex.Data.Add("Last token", t);

                throw ex;
            }
        }
        public void Visit(IOperatorToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesOperator;
            }
            else
            {
                Exception ex = new Exception("Invalid expression");

                ex.Source = "MathSyntaxScanner";
                ex.Data.Add("Last token", t);

                throw ex;
            }
        }

        /* Edges */
        private readonly ITokenPredicate edgesMathExp;
        private readonly ITokenPredicate edgesVariable;
        private readonly ITokenPredicate edgesNumber;
        private readonly ITokenPredicate edgesOperator;
        private readonly ITokenPredicate edgesLBracket;
        private readonly ITokenPredicate edgesRBracket;
        private readonly ITokenPredicate edgesFunctionName;

        /* Current edge */
        private ITokenPredicate edgesCurrent;
    }
}
