namespace MathOptimizer.Methods.Params
{
    //
    // Summary:
    //     Represents a data of input parameters for 
    //     optimization methods
    struct OutputParameters
    {
        public Interval ResultInterval { get; set; }
        public Vector ResultVecPoint   { get; set; }
        public double ResultPoint      { get; set; }
        public int Iterations          { get; set; }
    }
}
