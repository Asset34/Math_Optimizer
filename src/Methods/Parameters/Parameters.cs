namespace MathOptimizer.Methods.Params
{
    //
    // Summary:
    //     Represents a data of all parameters for 
    //     optimization methods
    struct Parameters
    {
        public InputParameters inParameters;
        public OutputParameters outParameters;

        public void SwapParameters()
        {
            inParameters.StartInterval = outParameters.ResultInterval;
            inParameters.StartPoint = outParameters.ResultPoint;
        }
    }
}
