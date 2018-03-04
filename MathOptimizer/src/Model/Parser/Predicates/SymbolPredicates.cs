namespace MathOptimizer.Model.Parser.Predicates
{
    class LetterPr : IPredicateOf1<char>
    {
        public bool Execute(char ch) { return char.IsLetter(ch); }
    }

    class DigitPr : IPredicateOf1<char>
    {
        public bool Execute(char ch) { return char.IsDigit(ch); }
    }

    class OperatorPr : IPredicateOf1<char>
    {
        public bool Execute(char ch) { return Tables.BinaryOperatorsPriorityTable.ContainsKey(ch); }
    }

    class LBracketPr : IPredicateOf1<char>
    {
        public bool Execute(char ch) {  return ch == '('; }
    }

    class RBracketPr : IPredicateOf1<char>
    {
        public bool Execute(char ch) { return ch == ')'; }
    }

    class UnderscorePr : IPredicateOf1<char>
    {
        public bool Execute(char ch) { return ch == '_'; }
    }

    class CommaPr : IPredicateOf1<char>
    {
        public bool Execute(char ch) { return ch == ','; }
    }

    class SemicolonPr : IPredicateOf1<char>
    {
        public bool Execute(char ch) { return ch == ';'; }
    }
}
