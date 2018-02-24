namespace MathOptimizer.Parser.Predicates
{
    public interface IPredicateOf1<T>
    {
        bool Execute(T t);
    }

    public interface IPredicateOf2<T1, T2>
    {
        bool Execute(T1 t1, T2 t2);
    }
}
