using MathOptimizer.Entities;

namespace MathOptimizer.Methods.Params
{
    /// <summary>
    /// Data class which contains input parameters of
    /// optimization methods
    /// </summary>
    class InputParameters
    {
        /// <summary>
        /// Starting interval of localization
        /// </summary>
        public Interval StartInterval { get; set; }
        /// <summary>
        /// Starting vector of multidimensional localization
        /// </summary>
        public Vector StartVecPoint { get; set; }
        /// <summary>
        /// Starting point of one-dimensional(or directional)
        /// optimization
        /// </summary>
        public double StartPoint { get; set; }
        /// <summary>
        /// Coefficient which defines the starting value of the step
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
