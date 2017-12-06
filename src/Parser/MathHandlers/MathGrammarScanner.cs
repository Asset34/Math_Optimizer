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
    //     <MathExp>  ::= <UnaryOp> <Operand> { <BinaryOp> <Operand> }*
    //     <Operand>  ::= <Variable> | <Constant > | <Number> | <Function> | '(' <MathExp> ')'
    //     <Function> ::= <FunctionName> '(' <MathExp> ')'
    class MathGrammarScanner : EmptyTokenVisitor
    {
        public static void Scann(List<IToken> tokens)
        {
            // Reset handler
            grammarScanner.Reset();

            // Handle tokens
            foreach (IToken t in tokens)
            {
                t.Accept(grammarScanner);
            }

            grammarScanner.CompareBracketCounters();
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
        public override void Visit(IConstantToken t)
        {
            if (edgesCurrent.Execute(t))
            {
                edgesCurrent = edgesConstant;
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
                edgesCurrent = edgeslbracket;

                counterlbracket++;
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
                edgesCurrent = edgesrbracket;

                counterrbracket++;
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

        private MathGrammarScanner()
        {
            /* Build FSM */

            // Terminal symbols
            ITokenPredicate variable = new VariableTokenPredicate();
            ITokenPredicate constant = new ConstantTokenPredicate();
            ITokenPredicate number = new NumberTokenPredicate();
            ITokenPredicate binaryOp = new BinaryOpTokenPredicate();
            ITokenPredicate unaryOp = new UnaryOpTokenPredicate();
            ITokenPredicate functionName = new FunctionNameTokenPredicate();
            ITokenPredicate lbracket = new LBracketrTokenPredicate();
            ITokenPredicate rbracket = new RBracketTokenPredicate();

            DisjunctionTokenPredicate disjunctionPr = new DisjunctionTokenPredicate();

            // MathExp
            disjunctionPr.Predicates.Add(variable);
            disjunctionPr.Predicates.Add(constant);
            disjunctionPr.Predicates.Add(number);
            disjunctionPr.Predicates.Add(functionName);
            disjunctionPr.Predicates.Add(lbracket);
            disjunctionPr.Predicates.Add(unaryOp);

            edgesMathExp = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // Variable
            disjunctionPr.Predicates.Add(binaryOp);
            disjunctionPr.Predicates.Add(rbracket);

            edgesVariable = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // RBracket
            disjunctionPr.Predicates.Add(binaryOp);
            disjunctionPr.Predicates.Add(rbracket);

            edgesrbracket = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // UnaryOp
            disjunctionPr.Predicates.Add(variable);
            disjunctionPr.Predicates.Add(number);
            disjunctionPr.Predicates.Add(constant);
            disjunctionPr.Predicates.Add(functionName);
            disjunctionPr.Predicates.Add(lbracket);

            edgesUnaryOp = disjunctionPr;
            disjunctionPr = new DisjunctionTokenPredicate();

            // Number
            edgesNumber = edgesVariable;

            // Constant
            edgesConstant = edgesVariable;

            // BinaryOp
            edgesBinaryOp = edgesMathExp;

            // LBracket
            edgeslbracket = edgesMathExp;

            // FunctionName
            edgesFunctionName = lbracket;

            /* Set start edges */
            edgesCurrent = edgesMathExp;
        }
        private void Reset()
        {
            // Reset handler 
            grammarScanner.counterlbracket = 0;
            grammarScanner.counterrbracket = 0;

            // Reset start edge
            edgesCurrent = edgesMathExp;
        }
        private void throwException(IToken lastToken)
        {
            Exception ex = new Exception("Invalid expression");

            ex.Source = "MathSyntaxScanner";
            ex.Data.Add(lastToken.GetType().ToString(), lastToken.ToString());

            throw ex;
        }
        private void CompareBracketCounters()
        {
            if (counterlbracket > counterrbracket)
            {
                Exception ex = new Exception("Invalid expression - Missing ')'");

                ex.Source = "MathSyntaxScanner";

                throw ex;
            }
            else if (counterlbracket < counterrbracket)
            {
                Exception ex = new Exception("Invalid expression - Missing '('");

                ex.Source = "MathSyntaxScanner";

                throw ex;
            }
        }

        /* Handler */
        private static MathGrammarScanner grammarScanner = new MathGrammarScanner();

        /* Edges */
        private readonly ITokenPredicate edgesMathExp;
        private readonly ITokenPredicate edgesVariable;
        private readonly ITokenPredicate edgesConstant;
        private readonly ITokenPredicate edgesNumber;
        private readonly ITokenPredicate edgesBinaryOp;
        private readonly ITokenPredicate edgesUnaryOp;
        private readonly ITokenPredicate edgeslbracket;
        private readonly ITokenPredicate edgesrbracket;
        private readonly ITokenPredicate edgesFunctionName;

        /* Current edge */
        private ITokenPredicate edgesCurrent;

        /* Bracket counters */
        private int counterlbracket;
        private int counterrbracket;
    }
}
