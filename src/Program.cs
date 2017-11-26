using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathOptimizer.Parser;
using MathOptimizer.Parser.Predicates;
using MathOptimizer.Parser.TokenFactories;
using MathOptimizer.Parser.Tokens;

namespace MathOptimizer
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void Test1()
        {
            string data = "15,2435*x12 + 12,5423";
            Position start = new Parser.Position(data, 14);

            if (NumberFactory.Check(start))
            {
                INumberToken token = NumberFactory.TakeToken(start);
                Console.WriteLine("{0}", token);
            }
        }
    }
}
