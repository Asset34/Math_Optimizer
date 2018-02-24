using System;
using System.Collections.Generic;

namespace MathOptimizer.Parser.Predicates
{
    class DisjunctionPrOf1<T> : IPredicateOf1<T>
    {
        public List<IPredicateOf1<T>> Predicates { get; }

        public DisjunctionPrOf1()
        {
            Predicates = new List<IPredicateOf1<T>>();
        }
        public bool Execute(T t)
        {
            foreach (IPredicateOf1<T> pr in Predicates)
            {
                if (pr.Execute(t))
                {
                    return true;
                }
            }

            return false;
        }
    }

    class DisjunctionPrOf2<T1, T2> : IPredicateOf2<T1, T2>
    {
        public List<IPredicateOf2<T1, T2>> Predicates { get; }

        public DisjunctionPrOf2()
        {
            Predicates = new List<IPredicateOf2<T1, T2>>();
        }
        public bool Execute(T1 t1, T2 t2)
        {
            foreach (IPredicateOf2<T1, T2> pr in Predicates)
            {
                if (pr.Execute(t1, t2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
