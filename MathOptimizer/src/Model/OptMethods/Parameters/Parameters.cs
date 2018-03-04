namespace MathOptimizer.Model.Methods.Params
{
    /// <summary>
    /// Data class which contains all parameters of the
    /// optimization methods
    /// </summary>
    class Parameters
    {
        public InputParameters Input { get; }
        public OutputParameters Output { get; }

        public Parameters()
        {
            Input = new InputParameters();
            Output = new OutputParameters();
        }
    }
}
