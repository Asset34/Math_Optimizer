namespace MathOptimizer.Methods.Params
{
    struct OutputParameters
    {
        public Interval ResultInterval { get; set; }
        public Vector ResultVecPoint   { get; set; }
        public double ResultPoint      { get; set; }
        public int Iterations          { get; set; }
    }
}
