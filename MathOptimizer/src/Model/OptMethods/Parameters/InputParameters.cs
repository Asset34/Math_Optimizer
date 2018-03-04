using MathOptimizer.Model.Entities;

namespace MathOptimizer.Model.Methods.Params
{
    /// <summary>
    /// Data class which contains input parameters of
    /// optimization methods
    /// </summary>
    class InputParameters
    {
        /// <summary>
        /// Starting vector of multidimensional localization
        /// </summary>
        public Vector StartPoint { get; set; }
        /// <summary>
        /// Starting point of one-dimensional(or directional)
        /// optimization
        /// </summary>
        public double StepValue { get; set; }
        /// <summary>
        /// Coefficient of step splitting
        /// </summary>
        public double StepCoefficient { get; set; }
        /// <summary>
        /// The accuracy of the optimization
        /// </summary>
        public double Eps { get; set; }
        /// <summary>
        /// Maximum number of iterations of the optimization cycle
        /// </summary>
        public int IterationLimit { get; set; } 
    }
}
