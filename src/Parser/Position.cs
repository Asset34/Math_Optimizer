using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOptimizer.Parser
{
    //
    // Summary:
    //     Represents a position in specific text data
    class Position
    {
        string s;

        public Position(string data, int index)
        {
            this.data = data;
            this.index = index;
        }
        public Position(string data)
            : this(data, 0)
        {
        }
        public Position(Position pos)
        {
            this.data = pos.data;
            this.index = pos.index;
        }
        public static Position operator++(Position pos)
        {
            pos.index++;
            return pos;
        }
        public static Position operator--(Position pos)
        {
            pos.index--;
            return pos;
        }
        public static string MakeString(Position begin, Position end)
        {
            string result = begin.data;

            return result.Substring(begin.index, end.index - begin.index);
        }

        public char Current
        {
            get
            {
                if (index >= 0 && index < data.Length)
                {
                    return data[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public bool IsEnd
        {
            get
            {
                return index == data.Length;
            }
        }

        private readonly string data;
        private int index;
    }
}
