namespace MathOptimizer.Entities
{
    /// <summary>
    /// Represents the wrapper for function which convert multidimensional function
    /// to one-dimensional
    /// </summary>
    /// <remarks>
    /// It's applied for possibility to use one-dimensional methods for
    /// directional optimization of the vector functions
    /// </remarks>
    class ConvertedFunction : Function
    {
        public ConvertedFunction(Function function, Vector startPoint, Vector direction)
            : base(null, null)
        {
            m_function = function;

            m_startPoint = startPoint;
            m_direction = direction;
        }
        public override double Evaluate(params double[] values)
        {
            return m_function.Evaluate(m_startPoint + values[0] * m_direction);
        }

        private Vector m_startPoint;
        private Vector m_direction;

        private readonly Function m_function;
    }
}
