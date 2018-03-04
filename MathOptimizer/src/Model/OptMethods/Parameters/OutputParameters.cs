using MathOptimizer.Model.Entities;

namespace MathOptimizer.Model.Methods.Params
{
    /// <summary>
    /// Data class which contains output parameters of
    /// optimization methods
    /// </summary>
    class OutputParameters
    {
        /// <summary>
        /// The result vector of multidimensional optimization
        /// </summary>
        public Vector ResultPoint { get; set; }
        /// <summary>
        /// The total number of iterations
        /// </summary>
        public int Iterations { get; set; }
    }
}
