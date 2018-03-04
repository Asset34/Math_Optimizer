using System;
using System.Collections.Generic;

using MathOptimizer.Model.Parser.Predicates;

namespace MathOptimizer.Model.Parser.Handlers
{
    /// <summary>
    /// Handler of math expression which check sequence of tokens
    /// according to formal grammar
    /// </summary>
    /// <remarks>
    /// Formal Grammar:
    ///     <MathExp>  ::= <UnaryOp> <Operand> { <BinaryOp> <Operand> }*
    ///     <Operand>  ::= <Variable> | <Constant > | <Number> | <Function> | '(' <MathExp> ')' 
    ///     <Function> ::= <FunctionName> '(' <MathExp> ')'
    /// </remarks>
    class GrammarScanner : EmptyTokenVisitor
    {
        public GrammarScanner()
        {
            // Terminal symbols
            IPredicateOf1<IToken> variable      = new VariableTokenPr();
            IPredicateOf1<IToken> constant      = new ConstantTokenPr();
            IPredicateOf1<IToken> number        = new NumberTokenPr();
            IPredicateOf1<IToken> binaryOp      = new BinaryOpTokenPr();
            IPredicateOf1<IToken> unaryOp       = new UnaryOpTokenPr();
            IPredicateOf1<IToken> functionName  = new FuncNameTokenPr();
            IPredicateOf1<IToken> lbracket      = new LBracketrTokenPr();
            IPredicateOf1<IToken> rbracket      = new RBracketTokenPr();
            IPredicateOf1<IToken> funcSeparator = new FuncSeparatorPr();

            DisjunctionPrOf1<IToken> disjunctionPr = new DisjunctionPrOf1<IToken>();

            // MathExp
            disjunctionPr.Predicates.Add(variable);
            disjunctionPr.Predicates.Add(constant);
            disjunctionPr.Predicates.Add(number);
            disjunctionPr.Predicates.Add(functionName);
            disjunctionPr.Predicates.Add(lbracket);
            disjunctionPr.Predicates.Add(unaryOp);

            m_edgesMathExp = disjunctionPr;
            disjunctionPr = new DisjunctionPrOf1<IToken>();

            // Variable
            disjunctionPr.Predicates.Add(binaryOp);
            disjunctionPr.Predicates.Add(rbracket);
            disjunctionPr.Predicates.Add(funcSeparator);

            m_edgesVariable = disjunctionPr;
            disjunctionPr = new DisjunctionPrOf1<IToken>();

            // UnaryOp
            disjunctionPr.Predicates.Add(variable);
            disjunctionPr.Predicates.Add(number);
            disjunctionPr.Predicates.Add(constant);
            disjunctionPr.Predicates.Add(functionName);
            disjunctionPr.Predicates.Add(lbracket);

            m_edgesUnaryOp = disjunctionPr;
            disjunctionPr = new DisjunctionPrOf1<IToken>();

            // RBracket
            m_edgesrbracket = m_edgesVariable;

            // Number
            m_edgesNumber = m_edgesVariable;

            // Constant
            m_edgesConstant = m_edgesVariable;

            // BinaryOp
            m_edgesBinaryOp = m_edgesMathExp;

            // LBracket
            m_edgeslbracket = m_edgesMathExp;

            // FuncSeparator
            m_edgesFuncSeparator = m_edgesMathExp;

            // FunctionName
            m_edgesFuncName = lbracket;

            /* Set start edges */
            m_edgesCurrent = m_edgesMathExp;
        }
        public void Scann(List<IToken> tokens)
        {
            // Reset handler
            Reset();

            // Handle tokens
            foreach (IToken t in tokens)
            {
                t.Accept(this);
            }

            CheckBracketCounter();
        }
        
        public override void Visit(IVariableToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgesVariable;
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(IConstantToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgesConstant;
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(IFuncNameToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgesFuncName;

                FunctionEnter(t);
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(INumberToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgesNumber;
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(ILBracketToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgeslbracket;

                m_bracketCounter++;
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(IRBracketToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgesrbracket;

                m_bracketCounter--;

                if (m_bracketValues.Count !=0 && m_bracketCounter == m_bracketValues.Peek())
                {
                    FunctionLeave();
                }  
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(IFuncSeparatorToken t)
        {
            if (m_edgesCurrent.Execute(t) && m_functions.Count > 0)
            {
                m_edgesCurrent = m_edgesFuncSeparator;

                FunctionArgLeave();
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(IBinaryOpToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgesBinaryOp;
            }
            else
            {
                ThrowException(t);
            }
        }
        public override void Visit(IUnaryOpToken t)
        {
            if (m_edgesCurrent.Execute(t))
            {
                m_edgesCurrent = m_edgesUnaryOp;
            }
            else
            {
                ThrowException(t);
            }
        }
        
        private void Reset()
        {
            // Reset function stack
            m_functions.Clear();

            // Reset counters
            m_argsCounters.Clear();
            m_maxArgs.Clear();
            m_bracketValues.Clear();
            m_bracketCounter = 0;

            // Reset start edge
            m_edgesCurrent = m_edgesMathExp;
        }
        private void ThrowException(IToken lastToken)
        {
            Exception ex = new Exception("Invalid expression");
            ex.Source = "ExpParser(GrammarScanner)";

            List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
            errors.Add(new KeyValuePair<string, string>(lastToken.ToString(), "Token"));
            ex.Data.Add("Errors", errors);

            throw ex;
        }
        private void CheckBracketCounter()
        {
            if (m_bracketCounter != 0)
            {
                Exception ex = new Exception("Invalid expression");
                ex.Source = "ExpParser(GrammarScanner)";
                List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
                if (m_bracketCounter < 0)
                {
                    errors.Add(new KeyValuePair<string, string>("(", "Missing"));
                }
                else
                {
                    errors.Add(new KeyValuePair<string, string>(")", "Missing"));
                }
                ex.Data.Add("Errors", errors);

                throw ex;
            }
        }

        private void FunctionEnter(IFuncNameToken t)
        {
            m_functions.Push(t.ToString());
            m_argsCounters.Push(0);
            m_maxArgs.Push(Tables.FunctionsArgsNumberTable[t.ToString()]);
            m_bracketValues.Push(m_bracketCounter);
        }
        private void FunctionLeave()
        {
            int args1 = m_maxArgs.Pop();
            int args2 = m_argsCounters.Pop() + 1;
            string funcName = m_functions.Pop();

            m_bracketValues.Pop();

            if (args1 != args2)
            {
                string msg;
                if (args2 < args1)
                {
                    msg = "Too few arguments in";
                }
                else
                {
                    msg = "Too many arguments in";
                }

                Exception ex = new Exception(msg);
                ex.Source = "GrammarScanner";
                List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
                errors.Add(new KeyValuePair<string, string>("Function", funcName));

                ex.Data.Add("Errors", errors);

                throw ex;
            }
        }
        private void FunctionArgLeave()
        {
            m_argsCounters.Push(m_argsCounters.Pop() + 1);
        }

        /* Counters */
        private Stack<int> m_argsCounters = new Stack<int>();
        private Stack<int> m_maxArgs = new Stack<int>();
        private Stack<int> m_bracketValues = new Stack<int>();
        private int m_bracketCounter;

        private Stack<string> m_functions = new Stack<string>();

        /* Edges */
        private IPredicateOf1<IToken> m_edgesCurrent;
        private readonly IPredicateOf1<IToken> m_edgesMathExp;
        private readonly IPredicateOf1<IToken> m_edgesVariable;
        private readonly IPredicateOf1<IToken> m_edgesConstant;
        private readonly IPredicateOf1<IToken> m_edgesNumber;
        private readonly IPredicateOf1<IToken> m_edgesBinaryOp;
        private readonly IPredicateOf1<IToken> m_edgesUnaryOp;
        private readonly IPredicateOf1<IToken> m_edgeslbracket; 
        private readonly IPredicateOf1<IToken> m_edgesrbracket;
        private readonly IPredicateOf1<IToken> m_edgesFuncSeparator;
        private readonly IPredicateOf1<IToken> m_edgesFuncName;
    }
}
