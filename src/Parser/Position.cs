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
        public static Position operator+(Position pos, int d)
        {
            return new Position(pos.data, pos.index + d);
        }
        public static Position operator-(Position pos, int d)
        {
            return new Position(pos.data, pos.index - d);
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
        public bool IsBegin
        {
            get { return index == -1; }
        }
        public bool IsEnd
        {
            get{ return index == data.Length; }
        }
        public int Number
        {
            get { return index; }
        }

        private readonly string data;
        private int index;
    }
}
