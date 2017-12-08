using System;
using System.Collections.Generic;

using MathOptimizer.Parser.ExpTree;

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
        public delegate IExpNode FunctionOperation(params IExpNode[] args);

        public static Dictionary<string, double> TempConstantsTable
        {
            get { return tempConstantsTable; }
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
        private static Dictionary<string, double> tempConstantsTable = new Dictionary<string, double>();

        /* Constants tabls */
        private static readonly Dictionary<string, double> constantsTable = new Dictionary<string, double>()
        {
            {"PI", Math.PI},
            {"E" , Math.E }
        };

        /* Binary Operators tables */
        private static readonly Dictionary<char, int> binaryOperatorsPriorityTable = new Dictionary<char, int>()
        {
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2},
            {'^', 3}
        };
        private static readonly Dictionary<char, BinaryOperation> binaryOperatorsExpTable = new Dictionary<char, BinaryOperation>()
        {
            {'+', (op1, op2) => (new PlusExp     (op1, op2))},
            {'-', (op1, op2) => (new MinusExp    (op1, op2))},
            {'*', (op1, op2) => (new MultyExp    (op1, op2))},
            {'/', (op1, op2) => (new DivisionExp (op1, op2))},
            {'^', (op1, op2) => (new PowerExp    (op1, op2))}
        };

        /* Unary Operators tables */
        private static readonly Dictionary<char, int> unaryOperatorsPriorityTable = new Dictionary<char, int>()
        {
            {'+', 4},
            {'-', 4}
        };
        private static readonly Dictionary<char, UnaryOperation> unaryOperatorsExpTable = new Dictionary<char, UnaryOperation>()
        {
            {'+', (op) => (null)                 },
            {'-', (op) => (new UnaryMinusExp(op))}
        };

        /* Functions tables */
        private static readonly Dictionary<string, int> functionsArgsNumberTable = new Dictionary<string, int>()
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
        private static readonly Dictionary<string, FunctionOperation> functionsExpTable = new Dictionary<string, FunctionOperation>()
        {
            {"sin"    , (args) => (new SinExp      (args[0]))         },
            {"cos"    , (args) => (new CosExp      (args[0]))         },
            {"tg"     , (args) => (new TgExp       (args[0]))         },
            {"ctg"    , (args) => (new CtgExp      (args[0]))         },
            {"arcsin" , (args) => (new ArcSinExp   (args[0]))         },
            {"arccos" , (args) => (new ArcCosExp   (args[0]))         },
            {"arctg"  , (args) => (new ArcTgExp    (args[0]))         },
            {"arcctg" , (args) => (new ArcCtgExp   (args[0]))         },
            {"ln"     , (args) => (new LnExp       (args[0]))         },
            {"exp"    , (args) => (new ExponentExp (args[0]))         },
            {"sqrt"   , (args) => (new SqrtExp     (args[0]))         },
            {"abs"    , (args) => (new AbsExp      (args[0]))         }, 
            {"sign"   , (args) => (new SignExp     (args[0]))         },
            {"log"    , (args) => (new LogExp      (args[0], args[1]))},
            {"min"    , (args) => (new MinExp      (args[0], args[1]))},
            {"max"    , (args) => (new MaxExp      (args[0], args[1]))}
        };
    }
}
