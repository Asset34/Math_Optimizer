namespace MathOptimizer.Methods.Params
{
    //
    // Summary:
    //     Represents a data of all parameters for 
    //     optimization methods
    struct Parameters
    {
        public InputParameters InParameters;
        public OutputParameters OutParameters;

        public void SwapParameters()
        {
            InParameters.StartInterval = OutParameters.ResultInterval;
            InParameters.StartPoint = OutParameters.ResultPoint;
        }
    }
}
