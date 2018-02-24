using System;

using MathOptimizer.Entities;
using MathOptimizer.Parser.Predicates;

namespace MathOptimizer.Parser.TokenReaders
{
    /// <summary>
    /// Class which try to read 'VariableToken', 'ConstantToken' and
    /// 'FuncNameToken' from the spicific position
    /// </summary>
    partial class IdentifierReader : TokenReader
    {
        public override bool Check(Position pos)
        {
            return Utills.Check(pos, beginVarPr);
        }
        public override IToken TakeToken(Position pos)
        {
            if (Check(pos))
            {
                Position start = new Position(pos);

                Utills.MoveWhile(pos, varPr);

                string strToken = Position.CreateString(start, pos);

                // Specificate indentificator
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
                ex.Source = "IdentifierReader";

                throw ex;
            }
        }

        private bool FunctionCheck(string strToken)
        {
            return Tables.FunctionsArgsNumberTable.ContainsKey(strToken);
        }
        private bool ConstantCheck(string strToken)
        {
            return Tables.ConstantsTable.ContainsKey(strToken) ||
                   Tables.TempConstantsTable.ContainsKey(strToken);
        }

        /* Used predicates */
        private readonly DisjunctionPrOf1<char> beginVarPr = new DisjunctionPrOf1<char>()
        {
            Predicates =
            {
                new UnderscorePr(),
                new LetterPr()
            }
        }; 
        private readonly DisjunctionPrOf1<char> varPr = new DisjunctionPrOf1<char>()
        {
            Predicates =
            {
                new UnderscorePr(),
                new LetterPr(),
                new DigitPr()
            }
        };
    }
}
