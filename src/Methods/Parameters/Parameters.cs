namespace MathOptimizer.Methods.Params
{
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
