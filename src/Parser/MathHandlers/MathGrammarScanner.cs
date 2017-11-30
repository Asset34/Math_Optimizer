using System;
using System.Collections.Generic;

using MathOptimizer.Parser.MathHandlers.TokenPredicates;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.MathHandlers
{
    //
    // Summary:
    //     Represents a part of the Parser which implement grammar analysis
    //     of the input math expression
    // 
    // Formal Grammar:
    //     <MathExp>  ::= <Operator> <Operand> { <Operator> <Operand> }*
    //     <Operand>  ::= <Variable> | <Constant > | <Number> | <Function> | '(' <MathExp> ')'
    //     <Function> ::= <FunctionName> '(' <MathExp> ')'
    class MathGrammarScanner : EmptyTokenVisitor
    {
        public static void Scann(List<IToken> tokens)
        {
            /* Reset counters */
            grammarScanner.counterLBracket = 0;
            grammarScanner.counterRBracket = 0;

            /* Handle tokens */
            foreach (IToken t in tokens)
            {
                t.Accept(grammarScanner);
            }

            grammarScanner.CompareCounters();
        }

        public MathGrammarScanner()
        {
            /* Build Finite-state machine */

            // Terminal symbols
            ITokenPredicate variable     = new VariableTokenPredicate();
            ITokenPredicate number       = new NumberTokenPredicate();
            ITokenPredicate binaryOp     = new BinaryOpTokenPredicate();
            ITokenPredicate unaryOp      = new UnaryOpTokenPredicate();
            ITokenPredicate functionName = new FunctionNameTokenPredicate();
            ITokenPredicate lBracket     = new LBracketrTokenPredicate();
            ITokenPredicate rBracket     = new RBracketTokenPredicate();

            DisjunctionTokenPredicate disjunctionPr = new DisjunctionTokenPredicate();

            // MathExp
            disjunctionPr.Predicates.Add(variable);
            disjunctionPr.Predicates.Add(number);
            disjunctionPr.Predicates.Add(functionName);
            disjunctionPr.Predicates.Add(lBracket);
            disjunctionPr.Predicates.Add(unaryOp);

            edgesMathExp = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // Variable
            disjunctionPr.Predicates.Add(binaryOp);
            disjunctionPr.Predicates.Add(rBracket);

            edgesVariable = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // RBracket
            disjunctionPr.Predicates.Add(binaryOp);
            disjunctionPr.Predicates.Add(rBracket);

            edgesRBracket = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // Unary Operator
            disjunctionPr.Predicates.Add(variable);
            disjunctionPr.Predicates.Add(number);
            disjunctionPr.Predicates.Add(functionName);
            disjunctionPr.Predicates.Add(lBracket);

            edgesUnaryOp = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // Number
            edgesNumber = edgesVariable;

            // Binary Operator
            edgesBinaryOp = edgesMathExp;

            // LBracket
            edgesLBracket = edgesMathExp;

            // FunctionName
            edgesFunctionName = lBracket;

            /* Set start edges */
            edgesCurrent = edgesMathExp;
        }

        public override void Visit(IVariableToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesVariable;
            }
            else
            {
                throwException(t);
            }
        }
        public override void Visit(IFunctionNameToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesFunctionName;
            }
            else
            {
                throwException(t);
            }
        }
        public override void Visit(INumberToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesNumber;
            }
            else
            {
                throwException(t);
            }
        }
        public override void Visit(ILBracketToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesLBracket;

                counterLBracket++;
            }
            else
            {
                throwException(t);
            }
        }
        public override void Visit(IRBracketToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesRBracket;

                counterRBracket++;
            }
            else
            {
                throwException(t);
            }
        }
        public override void Visit(IBinaryOpToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesBinaryOp;
            }
            else
            {
                throwException(t);
            }
        }
        public override void Visit(IUnaryOpToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesUnaryOp;
            }
            else
            {
                throwException(t);
            }
        }

        private static readonly MathGrammarScanner grammarScanner = new MathGrammarScanner();

        private void throwException(IToken lastToken)
        {
            Exception ex = new Exception("Invalid expression");

            ex.Source = "MathSyntaxScanner";
            ex.Data.Add("Token", lastToken.ToString());

            throw ex;
        }
        private void CompareCounters()
        {
            if (counterLBracket > counterRBracket)
            {
                Exception ex = new Exception("Invalid expression - Missing ')'");

                ex.Source = "MathSyntaxScanner";

                throw ex;
            }
            if (counterLBracket < counterRBracket)
            {
                Exception ex = new Exception("Invalid expression - Missing '('");

                ex.Source = "MathSyntaxScanner";

                throw ex;
            }
        }

        /* Edges */
        private readonly ITokenPredicate edgesMathExp;
        private readonly ITokenPredicate edgesVariable;
        private readonly ITokenPredicate edgesNumber;
        private readonly ITokenPredicate edgesBinaryOp;
        private readonly ITokenPredicate edgesUnaryOp;
        private readonly ITokenPredicate edgesLBracket;
        private readonly ITokenPredicate edgesRBracket;
        private readonly ITokenPredicate edgesFunctionName;

        /* Current edge */
        private ITokenPredicate edgesCurrent;

        /* Bracket counters */
        private int counterLBracket;
        private int counterRBracket;
    }
}
