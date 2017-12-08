using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Func.Tree;

namespace MathOptimizer.Parser
{
    //
    // Summary:
    //     Represents a complex of tables used by math handlers
    //          
    static class Tables
    {
        public delegate IExpNode BinaryOperation(IExpNode op1, IExpNode op2);
        public delegate IExpNode UnaryOperation(IExpNode op);
        public delegate IExpNode FunctionOperation(params IExpNode[] ops);

        public static Dictionary<string, double> ConstantsTable
        {
            get { return constantsTable; }
        }
        public static Dictionary<char, int> BinaryOperatorsPriorityTable
        {
            get { return binaryOperatorsPriorityTable; }
        }
        public static Dictionary<char, BinaryOperation> BinaryOperatorsExpTable
        {
            get { return binaryOperatorsExpTable; }
        }
        public static Dictionary<char, int> UnaryOperatorsPriorityTable
        {
            get { return unaryOperatorsPriorityTable; }
        }
        public static Dictionary<char, UnaryOperation> UnaryOperatorsExpTable
        {
            get { return unaryOperatorsExpTable; }
        }
        public static Dictionary<string, int> FunctionsArgsNumberTable
        {
            get { return functionsArgsNumberTable; }
        }
        public static Dictionary<string, FunctionOperation> FunctionsExpTable
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
            {'^', 3}
        };
        private static Dictionary<char, BinaryOperation> binaryOperatorsExpTable = new Dictionary<char, BinaryOperation>()
        {
            {'+', (op1, op2) => (new PlusExp     (op1, op2))},
            {'-', (op1, op2) => (new MinusExp    (op1, op2))},
            {'*', (op1, op2) => (new MultyExp    (op1, op2))},
            {'/', (op1, op2) => (new DivisionExp (op1, op2))},
            {'^', (op1, op2) => (new PowerExp    (op1, op2))}
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
            {"sin"    , 1},
            {"cos"    , 1},
            {"tg"     , 1},
            {"ctg"    , 1},
            {"arcsin" , 1},
            {"arccos" , 1},
            {"arctg"  , 1},
            {"arcctg" , 1},
            {"ln"     , 1},
            {"exp"    , 1},
            {"sqrt"   , 1},
            {"abs"    , 1},
            {"log"    , 2}
        };
        private static Dictionary<string, FunctionOperation> functionsExpTable = new Dictionary<string, FunctionOperation>()
        {
            {"sin"    , (ops) => (new SinExp      (ops[0]))},
            {"cos"    , (ops) => (new CosExp      (ops[0]))},
            {"tg"     , (ops) => (new TgExp       (ops[0]))},
            {"ctg"    , (ops) => (new CtgExp      (ops[0]))},
            {"arcsin" , (ops) => (new ArcSinExp   (ops[0]))},
            {"arccos" , (ops) => (new ArcCosExp   (ops[0]))},
            {"arctg"  , (ops) => (new ArcTgExp    (ops[0]))},
            {"arcctg" , (ops) => (new ArcCtgExp   (ops[0]))},
            {"ln"     , (ops) => (new LnExp       (ops[0]))},
            {"exp"    , (ops) => (new ExponentExp (ops[0]))},
            {"sqrt"   , (ops) => (new SqrtExp     (ops[0]))},
            {"abs"    , (ops) => (new AbsExp      (ops[0]))},
            {"log"    , (ops) => (new LogExp      (ops[0], ops[1]))}
        };
    }
}
