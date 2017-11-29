using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser.Interfaces;
using MathOptimizer.Parser.Interfaces.Tokens;
using MathOptimizer.Parser.Interfaces.Predicates;
using MathOptimizer.Parser.TokenFactories.GeneralPredicates;

namespace MathOptimizer.Parser.TokenFactories
{
    //
    // Summary:
    //     Represents a factory of a function name tokens
    class FunctionNameFactory
    {
        static FunctionNameFactory()
        {
            // Build a predicate for start of the function name
            beginFunctionNamePr.Predicates.Add(new Underscore());
            beginFunctionNamePr.Predicates.Add(new Letter());

            // Build a predicate for other part of the function name
            functionNamePr.Predicates.Add(beginFunctionNamePr);
            functionNamePr.Predicates.Add(new Digit());
        }
        public static bool Check(Position pos)
        {
            return Utills.Check(pos, beginFunctionNamePr);
        }
        public static IFunctionNameToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                Utills.MoveWhile(pos, functionNamePr);
                
                return new FunctionNameToken(Position.MakeString(start, pos), 0);
            }
            else
            {
                Exception ex = new Exception("Cannot take the token");

                ex.Source = "FunctionNameFactory";
                ex.Data.Add("Position", pos.Number);

                throw ex;
            }
        }

        /* Produced token */
        private class FunctionNameToken : IFunctionNameToken
        {
            public FunctionNameToken(string str, int priority)
            {
                this.value = str;
                Priority = priority;
            }
            public void Accept(ITokenVisitor visitor)
            {
                visitor.Visit(this);
            }
            public override string ToString()
            {
                return value;
            }

            public int Priority { get; }

            private readonly string value;
        }

        /* Used predicates */
        private static readonly Digit digitPr = new Digit();
        private static readonly Underscore underscorePr = new Underscore();
        private static readonly Letter letterPr = new Letter();

        private static DisjunctionCharPredicate beginFunctionNamePr = new DisjunctionCharPredicate();
        private static DisjunctionCharPredicate functionNamePr = new DisjunctionCharPredicate();

        private FunctionNameFactory() {}

        /* Function names table */
        private static string[] functionNamesTable = new string[]
        {
            "sin" , "cos", "tg",
            "ctg" , "exp", "ln",
            "sqrt"
        };
    }
}
