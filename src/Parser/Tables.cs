using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Func.Tree;

namespace MathOptimizer.Parser
{
    static class Tables
    {
        public delegate ExpNode BinaryOperation(ExpNode op1, ExpNode op2);
        public delegate ExpNode UnaryOperation(ExpNode op);

        public static Dictionary<string, double>         ConstantsTable
        {
            get { return constantsTable; }
        }
        public static Dictionary<char, int>              BinaryOperatorsPriorityTable
        {
            get { return binaryOperatorsPriorityTable; }
        }
        public static Dictionary<char, BinaryOperation>  BinaryOperatorsExpTable
        {
            get { return binaryOperatorsExpTable; }
        }
        public static Dictionary<char, int>              UnaryOperatorsPriorityTable
        {
            get { return unaryOperatorsPriorityTable; }
        }
        public static Dictionary<char, UnaryOperation>   UnaryOperatorsExpTable
        {
            get { return unaryOperatorsExpTable; }
        }
        public static Dictionary<string, int>            FunctionsArgsNumberTable
        {
            get { return functionsArgsNumberTable; }
        }
        public static Dictionary<string, UnaryOperation> FunctionsExpTable
        {
            get { return functionsExpTable; }
        }

        /* Constants table */
        private static Dictionary<string, double> constantsTable = new Dictionary<string, double>()
        {
            {"PI", Math.PI},
            {"E" , Math.E }
        };

        /* Binary Operators tables */
        private static Dictionary<char, int> binaryOperatorsPriorityTable = new Dictionary<char, int>()
        {
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2},
            {'^', 3},
            {'#', 4}
        };
        private static Dictionary<char, BinaryOperation> binaryOperatorsExpTable = new Dictionary<char, BinaryOperation>()
        {
            {'+', (op1, op2) => (new PlusExp     (op1, op2))},
            {'-', (op1, op2) => (new MinusExp    (op1, op2))},
            {'*', (op1, op2) => (new MultyExp    (op1, op2))},
            {'/', (op1, op2) => (new DivisionExp (op1, op2))},
            {'^', (op1, op2) => (new PowerExp    (op1, op2))},
            {'#', (op1, op2) => (new IndexingExp (op1, op2))}
        };

        /* Unary Operators tables */
        private static Dictionary<char, int> unaryOperatorsPriorityTable = new Dictionary<char, int>()
        {
            {'+', 4},
            {'-', 4}
        };
        private static Dictionary<char, UnaryOperation> unaryOperatorsExpTable = new Dictionary<char, UnaryOperation>()
        {
            {'+', (op) => (null)                 },
            {'-', (op) => (new UnaryMinusExp(op))}
        };

        /* Functions tables */
        private static Dictionary<string, int> functionsArgsNumberTable = new Dictionary<string, int>()
        {
            {"sin" , 1},
            {"cos" , 1},
            {"tg"  , 1},
            {"ctg" , 1},
            {"ln"  , 1},
            {"exp" , 1},
            {"sqrt", 1}
        };

        private static Dictionary<string, UnaryOperation> functionsExpTable = new Dictionary<string, UnaryOperation>()
        {
            {"sin" , (op) => (new SinExp      (op))},
            {"cos" , (op) => (new CosExp      (op))},
            {"tg"  , (op) => (new TgExp       (op))},
            {"ctg" , (op) => (new CtgExp      (op))},
            {"ln"  , (op) => (new LnExp       (op))},
            {"exp" , (op) => (new ExponentExp (op))},
            {"sqrt", (op) => (new SqrtExp     (op))}
        };
    }
}
