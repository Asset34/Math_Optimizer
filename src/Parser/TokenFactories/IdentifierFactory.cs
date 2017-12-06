using System;
using System.Linq;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a identifier tokens
    //     (Variables and Function Names)
    //
    // Formal Grammar:
    //     <Identifier> ::= <Variable> | <FunctionName>
    //     <Variable>   ::= <Letter> { {<Letter>}* {<Underscore>}* {<Digit>}* }*
    //     <Letter>     ::= 'a' | ... | 'Z'
    //     <Underscore> ::= '_'
    //     <Digit>      ::= '0' | ... | '9'
    class IdentifierFactory
    {
        static IdentifierFactory()
        {
            // Build a predicate for start of the identifier
            beginVariablePr.Predicates.Add(new Underscore());
            beginVariablePr.Predicates.Add(new Letter());

            // Build a predicate for other part of the identifier
            variablePr.Predicates.Add(beginVariablePr);
            variablePr.Predicates.Add(new Digit());
        }
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, beginVariablePr);
        }
        public static IIdentifierToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                Utills.MoveWhile(pos, variablePr);

                string strToken = Position.MakeString(start, pos);

                /* Specificate indentificator */
                if (Tables.FunctionsTable.ContainsKey(strToken)) 
                {
                    return new FunctionNameToken(strToken);
                }
                else
                {
                    return new VariableToken(strToken);
                }
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "IdentifierFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced tokens */
        private class VariableToken : Token, IVariableToken
        {
            public VariableToken(string strToken)
                :base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
        private class FunctionNameToken : Token, IFunctionNameToken
        {
            public FunctionNameToken(string strToken)
                : base(strToken)
            {
            }
            public override void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        /* Local predicates */
        private class Letter : ICharPredicate
        {
            public bool Execute(char ch)
            {
                return Char.IsLetter(ch);
            }
        }
        private class Underscore : ICharPredicate
        {
            public bool Execute(char ch)
            {
                return ch == '_';
            }
        }

        /* Used predicates */
        private static DisjunctionCharPredicate beginVariablePr = new DisjunctionCharPredicate();
        private static DisjunctionCharPredicate variablePr = new DisjunctionCharPredicate();

        private IdentifierFactory() { }
    }
}
