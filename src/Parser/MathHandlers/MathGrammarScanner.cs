using System;
using System.Collections.Generic;

using MathOptimizer.Parser.Interfaces;
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
            foreach (IToken t in tokens)
            {
                t.Accept(grammarScanner);
            }
        }

        public MathGrammarScanner()
        {
            /* Build Finite-state machine */

            // Terminal symbols
            ITokenPredicate variable = new VariableTokenPredicate();
            ITokenPredicate number = new NumberTokenPredicate();
            ITokenPredicate op = new OperatorTokenPredicate();
            ITokenPredicate functionName = new FunctionNameTokenPredicate();
            ITokenPredicate lBracket = new LBracketrTokenPredicate();
            ITokenPredicate rBracket = new RBracketTokenPredicate();

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
            }
            else
            {
                throwException(t);
            }
        }
        public override void Visit(IOperatorToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesOperator;
            }
            else
            {
                Exception ex = new Exception("Invalid expression");

                ex.Source = "MathSyntaxScanner";
                ex.Data.Add("Last token", t.ToString());

                throw ex;
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
