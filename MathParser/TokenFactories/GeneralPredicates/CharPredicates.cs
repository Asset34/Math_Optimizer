using System;

using MathOptimizer.Parser.Interfaces.Predicates;

namespace MathOptimizer.Parser.TokenFactories.GeneralPredicates
{
    class Letter : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return Char.IsLetter(ch);
        }
    }

    class Digit : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return Char.IsDigit(ch);
        }
    }

    class Operator : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return Tables.BinaryOperatorsPriorityTable.ContainsKey(ch);
        }
    }

    class LBracket : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return ch == '(';
        }
    }

    class RBracket : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return ch == ')';
        }
    }

    class Underscore : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return ch == '_';
        }
    }

    class Comma : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return ch == ',';
        }
    }

    class Semicolon : ICharPredicate
    {
        public bool Execute(char ch)
        {
            return ch == ';';
        }
    }
}
