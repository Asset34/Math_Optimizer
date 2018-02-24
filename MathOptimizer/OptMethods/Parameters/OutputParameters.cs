using MathOptimizer.Entities;

namespace MathOptimizer.Methods.Params
{
    /// <summary>
    /// Data class which contains output parameters of
    /// optimization methods
    /// </summary>
    class OutputParameters
    {
        /// <summary>
        /// The result interval of localization
        /// </summary>
        public Interval ResultInterval { get; set; }
        /// <summary>
        /// The result vector of multidimensional optimization
        /// </summary>
        public Vector ResultVecPoint { get; set; }
        /// <summary>
        /// The result point of one-dimensional(of directional)
        /// optimization
        /// </summary>
        public double ResultPoint { get; set; }
        /// <summary>
        /// The total number of iterations
        /// </summary>
        public int Iterations { get; set; }
    }
}
