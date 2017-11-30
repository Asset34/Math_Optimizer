using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Func.Tree;
using MathOptimizer.Parser.Func;

namespace MathOptimizer.Parser.MathHandlers
{
    class MathFunctionCreator : EmptyTokenVisitor
    {
        public static Function Create(List<IToken> tokens)
        {
            mathFunctionCreator = new MathFunctionCreator();

            /* Handle tokens */
            foreach (IToken t in tokens)
            {
                t.Accept(mathFunctionCreator);
            }

            /* Create functuion */
            ExpNode expTree = mathFunctionCreator.expTree.Pop();
            string[] variables = mathFunctionCreator.variables.ToArray();

            return new Function(expTree, variables);
        }

        public override void Visit(INumberToken t)
        {
            expTree.Push(new NumberExp(t.Number));
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
        public override void Visit(IFunctionNameToken t)
        {
            ExpNode operand = expTree.Pop();

            expTree.Push(functionTable[t.ToString()](operand));
        }
        public override void Visit(IBinaryOpToken t)
        {
            ExpNode operand2 = expTree.Pop();
            ExpNode operand1 = expTree.Pop();

            expTree.Push(binaryOperatorTable[t.Operator](operand1, operand2));
        }
        public override void Visit(IUnaryOpToken t)
        {
            ExpNode operand = expTree.Pop();

            expTree.Push(unaryOperatorTable[t.Operator](operand));
        }

        private static MathFunctionCreator mathFunctionCreator ;

        private Stack<ExpNode> expTree = new Stack<ExpNode>();
        private List<string> variables = new List<string>();

        /* Binary operators table */
        private delegate ExpNode BinaryOperation(ExpNode op1, ExpNode op2);
        private Dictionary<char, BinaryOperation> binaryOperatorTable = new Dictionary<char, BinaryOperation>()
        {
            {'+', (op1, op2) => (new PlusExp     (op1, op2))},
            {'-', (op1, op2) => (new MinusExp    (op1, op2))},
            {'*', (op1, op2) => (new MultyExp    (op1, op2))},
            {'/', (op1, op2) => (new DivisionExp (op1, op2))},
            {'^', (op1, op2) => (new PowerExp    (op1, op2))}
        };

        /* Unary operators table */
        private delegate ExpNode UnaryOperation(ExpNode op);
        private Dictionary<char, UnaryOperation> unaryOperatorTable = new Dictionary<char, UnaryOperation>()
        {
            {'+', (op) => (null)                 },
            {'-', (op) => (new UnaryMinusExp(op))}
        };

        /* Functions table */
        private delegate ExpNode FunctionOperation(ExpNode op);
        private Dictionary<string, FunctionOperation> functionTable = new Dictionary<string, FunctionOperation>()
        {
            {"sin" , (op) => (new SinExp      (op))},
            {"cos" , (op) => (new CosExp      (op))},
            {"tg"  , (op) => (new TgExp       (op))},
            {"ctg" , (op) => (new CtgExp      (op))},
            {"ln"  , (op) => (new LnExp       (op))},
            {"exp" , (op) => (new ExponentExp (op))},
            {"sqrt", (op) => (new SqrtExp     (op))},
        };
    }
}
