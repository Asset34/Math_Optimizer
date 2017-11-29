using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Func.Tree;

namespace MathOptimizer.Parser.MathHandlers
{
    class OperationCreator : EmptyTokenVisitor
    {
        public static ExpNode Create(ExpNode operand1, ExpNode operand2, IToken t)
        {
            t.Accept(operationCreator);

            return operationCreator.binaryOperation(operand1, operand2);
        }
        public static ExpNode Create(ExpNode operand, IToken t)
        {
            t.Accept(operationCreator);

            return operationCreator.unaryFunction(operand);
        }

        public override void Visit(IOperatorToken t)
        {
            binaryOperation = binaryOperatorTable[t.Operator];
        }
        public override void Visit(IFunctionNameToken t)
        {
            unaryFunction = unaryFunctionTable[t.ToString()];
        }

        private static readonly OperationCreator operationCreator = new OperationCreator();

        private delegate ExpNode BinaryOperation(ExpNode op1, ExpNode op2);
        private delegate ExpNode UnaryFunction(ExpNode op);

        private BinaryOperation binaryOperation = null;
        private UnaryFunction unaryFunction = null;

        /* Binary operators table */
        Dictionary<char, BinaryOperation> binaryOperatorTable = new Dictionary<char, BinaryOperation>()
        {
            {'+', (op1, op2) => (new PlusExp    (op1, op2))},
            {'-', (op1, op2) => (new MinusExp   (op1, op2))},
            {'*', (op1, op2) => (new MultyExp   (op1, op2))},
            {'/', (op1, op2) => (new DivisionExp(op1, op2))},
            {'^', (op1, op2) => (new PowerExp   (op1, op2))}
        };

        /* Functions table */
        Dictionary<string, UnaryFunction> unaryFunctionTable = new Dictionary<string, UnaryFunction>()
        {
            {"sin" , (op) => (new SinExp     (op))},
            {"cos" , (op) => (new CosExp     (op))},
            {"tg"  , (op) => (new TgExp      (op))},
            {"ctg" , (op) => (new CtgExp     (op))},
            {"ln"  , (op) => (new LnExp      (op))},
            {"exp" , (op) => (new ExponentExp(op))},
            {"sqrt", (op) => (new SqrtExp    (op))},
        };
    }
}
