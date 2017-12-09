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
    //     <Identifier>   ::= <Variable> | <FunctionName> | <Constant>
    //     <Variable>     ::= <Letter> { {<Letter>}* {<Underscore>}* {<Digit>}* }*
    //     <Letter>       ::= 'a' | ... | 'Z'
    //     <Underscore>   ::= '_'
    //     <Digit>        ::= '0' | ... | '9'
    //     <FunctionName> ::= 'sin' | ... | 'log'
    //     <Constant>     ::= 'PI' | ... | 'E'
    class IdentifierFactory
    {
        public bool Check(Position pos)
        {
            return Utills.Check(pos, beginVariablePr);
        }
        public IIdentifierToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                Utills.MoveWhile(pos, variablePr);

                string strToken = Position.MakeString(start, pos);

                /* Specificate indentificator */
                if (FunctionCheck(strToken)) 
                {
                    return new FunctionNameToken(strToken);
                }
                else if (ConstantCheck(strToken))
                {
                    return new ConstantToken(strToken);
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

        private bool FunctionCheck(string strToken)
        {
            return Tables.FunctionsArgsNumberTable.ContainsKey(strToken);
        }
        private bool ConstantCheck(string strToken)
        {
            return Tables.ConstantsTable.ContainsKey(strToken);
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
        private class ConstantToken : Token, IConstantToken
        {
            public ConstantToken(string strToken)
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
        private readonly DisjunctionCharPredicate beginVariablePr = new DisjunctionCharPredicate()
        {
            Predicates =
            {
                new Underscore(),
                new Letter()
            }
        };
        private readonly DisjunctionCharPredicate variablePr = new DisjunctionCharPredicate()
        {
            Predicates =
            {
                new Underscore(),
                new Letter(),
                new Digit()
            }
        };
    }
}
