using System;

namespace MathOptimizer.Model.Entities
{
    /// <summary>
    /// Represents the 'Iterator' of the specific text data
    /// </summary>
    class Position
    {
        /// <summary>
        /// Current symbol appropriated to the index
        /// </summary>
        public char Current
        {
            get
            {
                if (Index < 0 || Index >= m_data.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return m_data[Index];
            }
        }
        /// <summary>
        /// Current value of poition
        /// </summary>
        public int Index { get; private set; }

        public bool IsBegin
        {
            get { return Index == -1; }
        }
        public bool IsEnd
        {
            get { return Index == m_data.Length; }
        }   

        public Position(string data, int index = 0)
        {
            m_data = data;
            Index = index;
        }
        public Position(Position pos)
        {
            m_data = pos.m_data;
            Index = pos.Index;
        }

        public static Position operator++(Position pos)
        {
            pos.Index++;
            return pos;
        }
        public static Position operator--(Position pos)
        {
            pos.Index--;
            return pos;
        }
        public static Position operator+(Position pos, int d)
        {
            return new Position(pos.m_data, pos.Index + d);
        }
        public static Position operator-(Position pos, int d)
        {
            return new Position(pos.m_data, pos.Index - d);
        }

        /// <summary>
        /// Take string between two positions in the same text data
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string CreateString(Position begin, Position end)
        {
            string result = begin.m_data;
            return result.Substring(begin.Index, end.Index - begin.Index);
        }

        private readonly string m_data;
    }
}
