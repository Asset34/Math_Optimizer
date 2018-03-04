using System;
using System.Collections.Generic;

using MathOptimizer.Model.Parser.ExpTree;

namespace MathOptimizer.Model.Parser
{
    /// <summary>
    /// Parsing tables
    /// </summary>
    static class Tables
    {
        public delegate ExpNode BinaryOperation(ExpNode op1, ExpNode op2);
        public delegate ExpNode UnaryOperation(ExpNode op);
        public delegate ExpNode FunctionOperation(params ExpNode[] args);

        public static Dictionary<string, double> TempConstantsTable
        {
            get { return tempConstantsTable; }
            set { tempConstantsTable = value; }
        }
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

        /* Dynamic tables */
        private static Dictionary<string, double> tempConstantsTable;

        /* Constants tables */
        private static readonly Dictionary<string, double> constantsTable
            = new Dictionary<string, double>()
        {
            {"PI", Math.PI},
            {"E" , Math.E }
        };

        /* Binary Operators tables */
        private static readonly Dictionary<char, int> binaryOperatorsPriorityTable
            = new Dictionary<char, int>()
        {
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2},
            {'^', 3}
        };
        private static readonly Dictionary<char, BinaryOperation> binaryOperatorsExpTable
            = new Dictionary<char, BinaryOperation>()
        {
            {'+', (op1, op2) => (new PlusNode     (op1, op2))},
            {'-', (op1, op2) => (new MinusNode    (op1, op2))},
            {'*', (op1, op2) => (new MultyNode    (op1, op2))},
            {'/', (op1, op2) => (new DivisionNode (op1, op2))},
            {'^', (op1, op2) => (new PowerNode    (op1, op2))}
        };

        /* Unary Operators tables */
        private static readonly Dictionary<char, int> unaryOperatorsPriorityTable
            = new Dictionary<char, int>()
        {
            {'+', 4},
            {'-', 4}
        };
        private static readonly Dictionary<char, UnaryOperation> unaryOperatorsExpTable
            = new Dictionary<char, UnaryOperation>()
        {
            {'+', (op) => (null)                 },
            {'-', (op) => (new UnaryMinusNode(op))}
        };

        /* Functions tables */
        private static readonly Dictionary<string, int> functionsArgsNumberTable
            = new Dictionary<string, int>()
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
            {"sign"   , 1},
            {"log"    , 2},
            {"min"    , 2},
            {"max"    , 2}
        };
        private static readonly Dictionary<string, FunctionOperation> functionsExpTable
            = new Dictionary<string, FunctionOperation>()
        {
            {"sin"    , (args) => (new SinNode   (args[0]         ))},
            {"cos"    , (args) => (new CosNode   (args[0]         ))},
            {"tg"     , (args) => (new TgNode    (args[0]         ))},
            {"ctg"    , (args) => (new CtgNode   (args[0]         ))},
            {"arcsin" , (args) => (new ArcsinNode(args[0]         ))},
            {"arccos" , (args) => (new ArccosNode(args[0]         ))},
            {"arctg"  , (args) => (new ArctgNode (args[0]         ))},
            {"arcctg" , (args) => (new ArcctgNode(args[0]         ))},
            {"ln"     , (args) => (new LnNode    (args[0]         ))},
            {"exp"    , (args) => (new ExNode    (args[0]         ))},
            {"sqrt"   , (args) => (new SqrtNode  (args[0]         ))},
            {"abs"    , (args) => (new AbsNode   (args[0]         ))}, 
            {"sign"   , (args) => (new SignNode  (args[0]         ))},
            {"log"    , (args) => (new LogNode   (args[0], args[1]))},
            {"min"    , (args) => (new MinNode   (args[0], args[1]))},
            {"max"    , (args) => (new MaxNode   (args[0], args[1]))}
        };
    }
}
